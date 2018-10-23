using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Interfaces;
using CustomerService.Models;
using CustomerService.ViewModels;

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

        public async Task<int> AddOrUpdateCustomer(CustomerViewModel newCustomer)
        {

            if (!this.CustomerEmailExists(newCustomer))
            {
                await Task.Run(() => customers.Add(
                    this.ProcessedCustomerToInser(newCustomer))
                );
            }
            else
            {
                await UpdateCustomer(newCustomer);
            }

            return this.GetCustomerId(newCustomer.Email);
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

        public async Task UpdateCustomer(CustomerViewModel newCustomer)
        {
            var oldCustomer = customers.Where(c => c.Email == newCustomer.Email).Select(c => c).FirstOrDefault();
            var oldCustomerIndex = customers.IndexOf(oldCustomer);

            await Task.Run(() =>
            {
                customers[oldCustomerIndex].Name = newCustomer.Name ?? oldCustomer.Name;
                customers[oldCustomerIndex].IBAN = newCustomer.IBAN ?? oldCustomer.IBAN;
                customers[oldCustomerIndex].Phone = newCustomer.Phone ?? oldCustomer.Phone;
                customers[oldCustomerIndex].Suffix = newCustomer.Suffix ?? oldCustomer.Suffix;
            });
        }

        private void InitializeCustomersList()
        {
            customers = this.dataProvider.InitializeCustomers().Result;
        }

        private Customer ProcessedCustomerToInser(CustomerViewModel customerToInsert)
        {
            var newCustomerId = customers.Max(c => c.Id) + 1;
            return new Customer(newCustomerId, customerToInsert);
        }

        private bool CustomerEmailExists(CustomerViewModel customerToInsert)
        {
            return customers.Any(c => c.Email == customerToInsert.Email);
        }

        private int GetCustomerId(string email)
        {
            return customers.Single(c => c.Email == email).Id;
        }
    }
}