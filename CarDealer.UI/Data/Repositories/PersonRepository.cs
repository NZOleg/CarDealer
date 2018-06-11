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

        public async Task<bool> IsPersonCustomer(int id) {
            var customer = await Context.Customers.Where(c => c.CustomerID == id ).SingleOrDefaultAsync();
            if (customer == null)
                return false;
            return true;

        }

        public async Task<string> GetEmployeeRole(int id)
        {
            var employee = await Context.Employees.Where(c => c.EmployeeID == id).SingleOrDefaultAsync();
            if (employee == null)
                return "";
            return employee.Role;

        }
        public async Task<string> GetPersonRole(int id)
        {
            if( await IsPersonCustomer(id))
            {
                return "customer";
            }
            string role = await GetEmployeeRole(id);
            if (role == "") throw new Exception("User's Role is not specified");
            return role;
        }

        public async Task<Person> GetCustomerByIdAsync(int id)
        {
            Person person =  await Context.People.Where(p => p.PersonID == id).SingleOrDefaultAsync();
            return person;
        }

        public async Task<ICollection<Person>> GetAllCustomersAsync()
        {
            ICollection<Person> people = await Context.People.Where(p => p.Customer != null).ToListAsync();
            return people;
        }
        public void AddCustomer(Person customer)
        {
            Context.People.Add(customer);
        }
    }
}
