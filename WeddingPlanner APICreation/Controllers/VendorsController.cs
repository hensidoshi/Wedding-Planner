using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly VendorsRepository _vendorRepository;

        public VendorsController(VendorsRepository vendorsRepository)
        {
            _vendorRepository = vendorsRepository;
        }

        // This VendorsController is used for calling methods from VendorsRepository

        [HttpGet]
        public IActionResult GetAllVendors()
        {
            var vendors = _vendorRepository.SelectAllVendors();
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorById(int id)
        {
            var vendor = _vendorRepository.SelectByPK(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVendor(int id)
        {
            var isDeleted = _vendorRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertVendor([FromBody] VendorsModel vendor)
        {
            if (vendor == null)
                return BadRequest();

            bool isInserted = _vendorRepository.Insert(vendor);
            if (isInserted)
                return Ok(new { Message = "Vendor Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the vendor");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendor(int id, [FromBody] VendorsModel vendor)
        {
            if (vendor == null || id != vendor.VendorID)
                return BadRequest();

            var isUpdated = _vendorRepository.Update(vendor);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }
    }
}
