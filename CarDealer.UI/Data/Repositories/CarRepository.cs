using CarDealer.DataAccess;
using CarDealer.UI.Helpers;
using CarDealer.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Data.Repositories
{
    public class CarRepository : GenericRepository<IndividualCar, CarDealerDbContext>, ICarRepository
    {
        public CarRepository(CarDealerDbContext context) : base(context)
        {
        }

        public async Task<CarModel> CreateOrAssignCarModelAsync(CarModel carModel)
        {
            CarModel currentCarModel = await Context.CarModels.Where(cm => cm.Manufacturer == carModel.Manufacturer && cm.Model == carModel.Model && cm.NumberOfSeats == carModel.NumberOfSeats)
                .SingleOrDefaultAsync();
            if (currentCarModel == null)
            {
                currentCarModel = carModel;
                Context.CarModels.Add(carModel);
                await SaveAsync();
            }
            return currentCarModel;
        }

        public async Task<CarModel> SaveCarModelAsync(CarModel carModel)
        {
            Context.CarModels.Add(carModel);
            await SaveAsync();
            return await Context.CarModels.Where(cm => cm.Manufacturer == carModel.Manufacturer && cm.Model == carModel.Model).SingleAsync();
        }

        public async Task<Collection<CarFeature>> GetAllCarFeatures()
        {
            return new Collection<CarFeature>(await Context.CarFeatures.ToListAsync());
        }

        public async Task<Collection<CarSale>> GetAllSalesAsync()
        {
            return new Collection<CarSale>(await Context.Cars_Sold.ToListAsync());
        }

        //public async Task<ICollection<CarFeature>> GetCarFeatures(int id)
        //{
        //    var car = await Context.IndividualCars.Where(c => c.CarID == id).SingleOrDefaultAsync();
        //    return car.CarFeatures;
        //}

        //public async Task<ICollection<Cars_Sold>> GetCarsSold(int id)
        //{
        //    var car = await Context.IndividualCars.Where(c => c.CarID == id).SingleOrDefaultAsync();
        //    return car.Cars_Sold;
        //}
        //public async Task<CarModel> GetCarModel(int id)
        //{
        //    var car = await Context.IndividualCars.Where(c => c.CarID == id).SingleOrDefaultAsync();
        //    return car.CarModel;
        //}

        public async Task<Collection<IndividualCar>> ApplyFilterAsync(CarFiltersViewModel carFiltersViewModel)
        {
            var query = Context.IndividualCars.Where(ic => ic.Status == Constants.CAR_AVAILABLE);
            if (carFiltersViewModel.Manufacturer != "" && carFiltersViewModel.Manufacturer != null)
            {
                query = query.Where(ic => ic.CarModel.Manufacturer == carFiltersViewModel.Manufacturer);
            }
            if (carFiltersViewModel.Model != "" && carFiltersViewModel.Model != null)
            {
                query = query.Where(ic => ic.CarModel.Model == carFiltersViewModel.Model);
            }
            if (carFiltersViewModel.BodyType != "" && carFiltersViewModel.BodyType != null)
            {
                query = query.Where(ic => ic.BodyType == carFiltersViewModel.BodyType);
            }
            if (carFiltersViewModel.EngineSizeMin != null && carFiltersViewModel.EngineSizeMin != 0)
            {
                query = query.Where(ic => ic.CarModel.EngineSize >= carFiltersViewModel.EngineSizeMin);
            }
            if (carFiltersViewModel.EngineSizeMax != null && carFiltersViewModel.EngineSizeMax != 0)
            {
                query = query.Where(ic => ic.CarModel.EngineSize <= carFiltersViewModel.EngineSizeMax);
            }
            if (carFiltersViewModel.ManufactureYearMin != null && carFiltersViewModel.ManufactureYearMin != 0)
            {
                query = query.Where(ic => ic.ManufactureYear >= carFiltersViewModel.ManufactureYearMin);
            }
            if (carFiltersViewModel.ManufactureYearMax != null && carFiltersViewModel.ManufactureYearMax != 0)
            {
                query = query.Where(ic => ic.ManufactureYear <= carFiltersViewModel.ManufactureYearMax);
            }
            if (carFiltersViewModel.Transmission != "" && carFiltersViewModel.Transmission != null)
            {
                query = query.Where(ic => ic.Transmission == carFiltersViewModel.Transmission);
            }
            if (carFiltersViewModel.MileageMin != null && carFiltersViewModel.MileageMin != 0)
            {
                query = query.Where(ic => ic.CurrentMileage >= carFiltersViewModel.MileageMin);
            }
            if (carFiltersViewModel.MileageMax != null && carFiltersViewModel.MileageMax != 0)
            {
                query = query.Where(ic => ic.CurrentMileage <= carFiltersViewModel.MileageMax);
            }
            if (carFiltersViewModel.Colour != "" && carFiltersViewModel.Colour != null)
            {
                query = query.Where(ic => ic.Colour == carFiltersViewModel.Colour);
            }
            if (carFiltersViewModel.AskingPriceMin != null && carFiltersViewModel.AskingPriceMin != 0)
            {
                query = query.Where(ic => ic.AskingPrice >= carFiltersViewModel.AskingPriceMin);
            }
            if (carFiltersViewModel.AskingPriceMax != null && carFiltersViewModel.AskingPriceMax != 0)
            {
                query = query.Where(ic => ic.AskingPrice <= carFiltersViewModel.AskingPriceMax);
            }
            if (carFiltersViewModel.SortByPopularity == SortBySalesEnum.LeastPopular)
            {
                query = query.OrderBy(ic => ic.CarSale.Count());
            }
            else
            {
                Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                query = query.OrderByDescending(ic => ic.CarSale.Count());
            }

            if (carFiltersViewModel.NumberOfCars != null && carFiltersViewModel.NumberOfCars != 0)
            {
                return new Collection<IndividualCar>(await query.Take((int)carFiltersViewModel.NumberOfCars).ToListAsync());
            }

            return new Collection<IndividualCar>(await query.ToListAsync());
        }

        public async Task<Collection<CarSale>> ApplySaleFilterAsync(SaleFiltersViewModel saleFiltersViewModel, SaleFilters saleFilter)
        {
            switch (saleFilter)
            {
                case SaleFilters.MonthFilter:
                    DateTime endDate = saleFiltersViewModel.SelectedMonth.AddMonths(1);
                    return new Collection<CarSale>(await Context.Cars_Sold.Where(cs => cs.Date >= saleFiltersViewModel.SelectedMonth && cs.Date < endDate).ToListAsync());
                case SaleFilters.RangeFilter:
                    var sales = Context.Cars_Sold.Where(cs => cs.IndividualCar != null); //fetch all cars
                    if (saleFiltersViewModel.StartDate != null)
                    {
                        sales = sales.Where(cs => cs.Date >= saleFiltersViewModel.StartDate);
                    }
                    if (saleFiltersViewModel.EndDate != null)
                    {
                        sales = sales.Where(cs => cs.Date <= saleFiltersViewModel.EndDate);
                    }
                    return new Collection<CarSale>(await sales.ToListAsync());
                default:
                    return null;
            }
        }


        public async Task CarIsSoldAsync(int id)
        {
            IndividualCar car = await Context.IndividualCars.Where(ic => ic.Id == id).SingleOrDefaultAsync();
            //have to comment it for part B
            //car.Status = Constants.CAR_UNAVAILABLE;
            await Context.SaveChangesAsync();
        }

        public void AddCarModel(CarModel carModel)
        {
            Context.CarModels.Add(carModel);

        }

    }
}
