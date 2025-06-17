using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _customerRepository;

        public CustomersController(CustomersRepository customersRepository)
        {
            _customerRepository = customersRepository;
        }

        // This CustomersController is used for calling methods from CustomersRepository

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.SelectAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.SelectByPK(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var isDeleted = _customerRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertCustomer([FromBody] CustomersModel customer)
        {
            if (customer == null)
                return BadRequest();

            bool isInserted = _customerRepository.Insert(customer);
            if (isInserted)
                return Ok(new { Message = "Customer Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the customer");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomersModel customer)
        {
            if (customer == null || id != customer.CustomerID)
                return BadRequest();

            var isUpdated = _customerRepository.Update(customer);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }
    }
}
