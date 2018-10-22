using CustomerService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Interfaces
{
    public interface IDataProvider
    {
        Task<List<Customer>> InitializeCustomers();
    }
}
