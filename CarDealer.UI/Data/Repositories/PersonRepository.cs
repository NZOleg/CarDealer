using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Data.Repositories
{
    class PersonRepository : GenericRepository<Person, CarDealerDbContext>, IPersonRepository
    {
        public PersonRepository(CarDealerDbContext context)
          : base(context)
        {
        }

        public async Task<Person> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await Context.People.Where(p => p.Username == username && p.Password == password).SingleOrDefaultAsync();
        }
    }
}
