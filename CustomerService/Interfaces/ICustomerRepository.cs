using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Models;
using CustomerService.ViewModels;

namespace CustomerService.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<int> AddOrUpdateCustomer(CustomerViewModel newCustomer);
        Task<Customer> GetCustomerById(int id);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(CustomerViewModel newCustomer);
    }
}
