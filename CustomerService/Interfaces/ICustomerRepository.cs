using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task AddNewCustomer(Customer newCustomer);
        Task<Customer> GetCustomerById(int id);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(int id, Customer newCustomer);
    }
}
