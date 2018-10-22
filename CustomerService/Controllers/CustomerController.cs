using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CustomerService.Data;
using CustomerService.Models;

namespace CustomerService.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Route("api/customers")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await this.customerRepository.GetAllCustomers();
        }

        [Route("api/customers/{id}")]
        [HttpDelete]
        public async Task DeleteCustomer([FromUri] int id)
        {
            await this.customerRepository.DeleteCustomer(id);
        }
    }
}
