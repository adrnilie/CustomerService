using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Interfaces;
using CustomerService.Models;

namespace CustomerService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDataProvider dataProvider;
        private static List<Customer> customers;

        public CustomerRepository(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            this.InitializeCustomersList();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await Task.Run(() => customers);
        }

        public async Task AddNewCustomer(Customer newCustomer)
        {
            await Task.Run(() => customers.Add(newCustomer));
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await Task.Run(() => customers.Single(c => c.Id == id));
        }

        public async Task DeleteCustomer(int id)
        {
            var itemToRemove = customers.Single(c => c.Id == id);
            await Task.Run(() => customers.Remove(itemToRemove));
        }

        public async Task UpdateCustomer(int id, Customer newCustomer)
        {
            var itemToEdit = customers.Single(c => c.Id == id);
        }

        private void InitializeCustomersList()
        {
            customers = this.dataProvider.InitializeCustomers().Result;
        }
    }
}