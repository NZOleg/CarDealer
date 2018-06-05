using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Data.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        Task<Person> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
