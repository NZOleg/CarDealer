using CarDealer.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Data.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        Task<Person> GetByUsernameAndPasswordAsync(string username, string password);
        Task<bool> IsPersonCustomer(int id);
        Task<string> GetEmployeeRole(int id);
        Task<string> GetPersonRole(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Collection<Customer>> GetAllCustomersAsync();
        void AddCustomer(Customer customer);
        Task AddNewSaleAsync(int carID, int customerID, Cars_Sold cars_Sold);
        Task<Collection<Cars_Sold>> GetAllCustomerCars(int id);
        void RemoveCustomer(Customer model);
        Task<Collection<Employee>> GetAllEmployeesAsync();
        void RemoveEmployee(Employee model);
        void AddEmployee(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}
