using CarDealer.DataAccess;
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

        public async Task<List<CarFeature>> getAllCarFeatures()
        {
            return await Context.CarFeatures.ToListAsync();
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

    }
}
