using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Interfaces;
using CustomerService.Models;

namespace CustomerService.Data
{
    public class DataProvider: IDataProvider
    {
        public Task<List<Customer>> InitializeCustomers()
        {
            return Task.Run(() => new List<Customer>()
            {
                new Customer(1, "Ritchie - Goldner", "Group", "BR4470705011079103006325006Y6", "Clare.Wolf@yahoo.com", "1-059-843-5759"),
                new Customer(2, "Beahan, Gusikowski and Daniel", "Group", "BG56YLQR010077G5S92648", "Isom.Olson65@gmail.com", "1-234-051-9716"),
                new Customer(3, "Pouros - Goodwin", "LLC", "LV71QGCJ074587078XF54", "Marlon.Reinger18@hotmail.com", "734-374-8314"),
                new Customer(4, "Sipes - Parisian", "Group", "LT131026856981017905", "Kitty.Bergnaum@yahoo.com", "839-690-9780"),
                new Customer(5, "Lakin Inc", "Inc", "LI67735038225787S307N", "Reyes.Haag@hotmail.com", "1-191-029-2376")
            });
        }
    }
}