using CarDealer.DataAccess;
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
        Task<Collection<Cars_Sold>> GetAllSalesAsync();
    }
}
