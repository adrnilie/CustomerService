using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CustomerService.Interfaces;
using CustomerService.Models;
using CustomerService.ViewModels;

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
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomerById([FromUri]int id)
        {
            try
            {
                var result = await this.customerRepository.GetCustomerById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [Route("api/customers/{id}")]
        [HttpDelete]
        public async Task DeleteCustomer([FromUri]int id)
        {
            await this.customerRepository.DeleteCustomer(id);
        }

        [Route("api/customers")]
        [HttpPost]
        [HttpPut]
        public async Task<IHttpActionResult> CreateOrUpdateCustomer([FromBody]CustomerViewModel customerToInsert)
        {
            var customerId = await this.customerRepository.AddOrUpdateCustomer(customerToInsert);

            return Ok($"Customer fully populated. Customer id is {customerId}");
        }
    }
}
