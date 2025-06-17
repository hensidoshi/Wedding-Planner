using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly GuestsRepository _guestsRepository;

        public GuestsController(GuestsRepository guestsRepository)
        {
            _guestsRepository = guestsRepository;
        }

        // This GuestsController is used for calling methods from GuestsRepository

        [HttpGet]
        public IActionResult GetAllGuests()
        {
            var guests = _guestsRepository.SelectAllGuests();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public IActionResult GetGuestById(int id)
        {
            var guest = _guestsRepository.SelectByPK(id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var isDeleted = _guestsRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertGuest([FromBody] GuestsModel guest)
        {
            if (guest == null)
                return BadRequest();

            bool isInserted = _guestsRepository.Insert(guest);
            if (isInserted)
                return Ok(new { Message = "Guest Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the guest");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGuest(int id, [FromBody] GuestsModel guest)
        {
            if (guest == null || id != guest.GuestID)
                return BadRequest();

            var isUpdated = _guestsRepository.Update(guest);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }
        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _guestsRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }
    }
}
