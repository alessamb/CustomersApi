using Microsoft.AspNetCore.Mvc;
using CustomersApi.Dtos;
using CustomersApi.Repositories;
using CustomersApi.Interface;

namespace CustomersApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDatabaseContext _databaseContext;
        private readonly IUpdateCustomer _updateCustomer;
        private readonly IAddCustomer _addCustomer;


        public CustomerController(CustomerDatabaseContext databaseContext, IUpdateCustomer updateCustomer, IAddCustomer addCustomer) 
        {
            _databaseContext = databaseContext;
            _updateCustomer = updateCustomer;
            _addCustomer = addCustomer;
        
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<bool> GetCustomer(long Id)
        {

            CustomerEntity customer =await _databaseContext.Get(Id);
            //return new OkObjectResult(customer.toDto());
            return true;
           // return View(customer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<CustomerDto>))]
        public async Task<IActionResult> GetCustomers()
        {

            var result = _databaseContext.customers.Select(x => x.toDto()).ToList();
            return new OkObjectResult(result);
        }


        [HttpDelete("id")]
        public async Task<Boolean> DeleteCustomer(long Id)
        {
            throw new NotImplementedException();

        }
       
        
        
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            int id = await _addCustomer.AddClient(customer);
            //CustomerEntity result = await _databaseContext.Add(customer);
            return new CreatedResult($"htpp://localhost:7116/api/customer/{id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customer)
        {
            var result = await _updateCustomer.Execute(customer);
            return new ObjectResult(result);
        }

    }

}