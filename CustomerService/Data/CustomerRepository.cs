using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> customers;

        public CustomerRepository()
        {
            InitializeCustomers();
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

        private static void InitializeCustomers()
        {
            customers = new List<Customer>()
            {
                new Customer(1, "Ritchie - Goldner", "Group", "BR4470705011079103006325006Y6", "Clare.Wolf@yahoo.com", "1-059-843-5759"),
                new Customer(2, "Beahan, Gusikowski and Daniel", "Group", "BG56YLQR010077G5S92648", "Isom.Olson65@gmail.com", "1-234-051-9716"),
                new Customer(3, "Pouros - Goodwin", "LLC", "LV71QGCJ074587078XF54", "Marlon.Reinger18@hotmail.com", "734-374-8314"),
                new Customer(4, "Sipes - Parisian", "Group", "LT131026856981017905", "Kitty.Bergnaum@yahoo.com", "839-690-9780"),
                new Customer(5, "Lakin Inc", "Inc", "LI67735038225787S307N", "Reyes.Haag@hotmail.com", "1-191-029-2376")
            };
        }
    }
}