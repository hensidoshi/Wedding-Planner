using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorBookingsController : ControllerBase
    {
        private readonly VendorBookingsRepository _vendorBookingsRepository;

        public VendorBookingsController(VendorBookingsRepository vendorBookingsRepository)
        {
            _vendorBookingsRepository = vendorBookingsRepository;
        }

        // This VendorBookingsController is used for calling methods from VendorBookingsRepository

        [HttpGet]
        public IActionResult GetAllVendorBookings()
        {
            var bookings = _vendorBookingsRepository.SelectAllVendorBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorBookingById(int id)
        {
            var booking = _vendorBookingsRepository.SelectByPK(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVendorBooking(int id)
        {
            var isDeleted = _vendorBookingsRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertVendorBooking([FromBody] VendorBookingsModel booking)
        {
            if (booking == null)
                return BadRequest();

            bool isInserted = _vendorBookingsRepository.Insert(booking);
            if (isInserted)
                return Ok(new { Message = "Vendor Booking Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the vendor booking");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendorBooking(int id, [FromBody] VendorBookingsModel booking)
        {
            if (booking == null || id != booking.BookingID)
                return BadRequest();

            var isUpdated = _vendorBookingsRepository.Update(booking);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _vendorBookingsRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }

        [HttpGet("vendors")]
        public IActionResult GetVendors()
        {
            var vendors = _vendorBookingsRepository.GetVendors();
            if (!vendors.Any())
                return NotFound("No vendors found.");

            return Ok(vendors);
        }
    }
}
