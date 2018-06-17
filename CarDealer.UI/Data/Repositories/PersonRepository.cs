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
            var customer = await Context.Customers.Where(c => c.Id == id ).SingleOrDefaultAsync();
            if (customer == null)
                return false;
            return true;

        }

        public async Task<string> GetEmployeeRole(int id)
        {
            var employee = await Context.Employees.Where(c => c.Id == id).SingleOrDefaultAsync();
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

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer person =  await Context.Customers.Where(p => p.Id == id).SingleOrDefaultAsync();
            return person;
        }

        public async Task<Collection<Customer>> GetAllCustomersAsync()
        {
            return new Collection<Customer>(await Context.Customers.ToListAsync());
            
        }

        public async Task AddNewSaleAsync(int carID, int customerID, CarSale cars_Sold)
        {
            IndividualCar car = await Context.IndividualCars.Where(ic => ic.Id == carID).SingleAsync();
            Customer customer = await Context.Customers.Where(c => c.Id == customerID).SingleAsync();
            cars_Sold.IndividualCar = car;
            customer.CarSale.Add(cars_Sold);
             await SaveAsync();
        }
        public void AddCustomer(Customer customer)
        {
            Context.Customers.Add(customer);
        }
        public void AddEmployee(Employee employee)
        {
            Context.Employees.Add(employee);
        }
        public void RemoveCustomer(Customer customer)
        {

            Context.Customers.Remove(customer);
            Context.People.Remove(customer.Person);
        }
        public void RemoveEmployee(Employee employee)
        {

            Context.Employees.Remove(employee);
            Context.People.Remove(employee.Person);
        }

        public async Task<Collection<Employee>> GetAllEmployeesAsync()
        {
            return new Collection<Employee>(await Context.Employees.ToListAsync());
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            Employee person = await Context.Employees.Where(p => p.Id == id).SingleOrDefaultAsync();
            return person;
        }

        public async Task<Collection<CarSale>> GetAllCustomerCars(int id)
        {
            var cars = await Context.Cars_Sold.Where(cs => cs.Customer.Id == id).ToListAsync();
            return new Collection<CarSale>(cars);
        }
    }
}
