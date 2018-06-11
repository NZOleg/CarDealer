using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
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
    }
}
