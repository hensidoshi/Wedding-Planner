using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentsRepository _paymentsRepository;

        public PaymentsController(PaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        // This PaymentsController is used for calling methods from PaymentsRepository

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var payments = _paymentsRepository.SelectAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _paymentsRepository.SelectByPK(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var isDeleted = _paymentsRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertPayment([FromBody] PaymentsModel payment)
        {
            if (payment == null)
                return BadRequest();

            bool isInserted = _paymentsRepository.Insert(payment);
            if (isInserted)
                return Ok(new { Message = "Payment Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the payment");
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, [FromBody] PaymentsModel payment)
        {
            if (payment == null || id != payment.PaymentID)
                return BadRequest();

            var isUpdated = _paymentsRepository.Update(payment);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _paymentsRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }

        [HttpGet("vendors")]
        public IActionResult GetVendors()
        {
            var vendors = _paymentsRepository.GetVendors();
            if (!vendors.Any())
                return NotFound("No vendors found.");

            return Ok(vendors);
        }

    }
}
