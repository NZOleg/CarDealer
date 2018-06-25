using CarDealer.DataAccess;
using CarDealer.UI.Helpers;
using CarDealer.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Data.Repositories
{
    public interface ICarRepository: IGenericRepository<IndividualCar>
    {
        //Task<ICollection<CarFeature>> GetCarFeatures(int id);
        //Task<ICollection<Cars_Sold>> GetCarsSold(int carID);
        //Task<CarModel> GetCarModel(int id);
        Task<CarModel> SaveCarModelAsync(CarModel carModel);
        Task<CarModel> CreateOrAssignCarModelAsync(CarModel carModel);
        Task<Collection<CarFeature>> GetAllCarFeatures();
        Task<Collection<CarSale>> GetAllSalesAsync();
        Task<Collection<IndividualCar>> ApplyFilterAsync(CarFiltersViewModel carFiltersViewModel);
        Task CarIsSoldAsync(int id);
        void AddCarModel(CarModel carModel);
        Task<Collection<CarSale>> ApplySaleFilterAsync(SaleFiltersViewModel saleFiltersViewModel, SaleFilters saleFilter);
    }
}
