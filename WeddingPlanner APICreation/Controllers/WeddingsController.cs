using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingsController : ControllerBase
    {
        private readonly WeddingsRepository _weddingRepository;

        public WeddingsController(WeddingsRepository weddingRepository)
        {
            _weddingRepository = weddingRepository;
        }

        // This WeddingsController is used for calling methods from WeddingsRepository

        [HttpGet]
        public IActionResult GetAllWeddings()
        {
            var weddings = _weddingRepository.SelectAllWeddings();
            return Ok(weddings);
        }

        [HttpGet("{id}")]
        public IActionResult GetWeddingById(int id)
        {
            var wedding = _weddingRepository.SelectByPK(id);
            if (wedding == null)
            {
                return NotFound();
            }
            return Ok(wedding);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWedding(int id)
        {
            var isDeleted = _weddingRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertWedding([FromBody] WeddingsModel wedding)
        {
            if (wedding == null)
                return BadRequest();

            bool isInserted = _weddingRepository.Insert(wedding);
            if (isInserted)
                return Ok(new { Message = "Wedding Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the wedding");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWedding(int id, [FromBody] WeddingsModel wedding)
        {
            if (wedding == null || id != wedding.WeddingID)
                return BadRequest();

            var isUpdated = _weddingRepository.Update(wedding);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("clients")]
        public IActionResult GetClients()
        {
            var clients = _weddingRepository.GetClients();
            if (!clients.Any())
                return NotFound("No clients found.");

            return Ok(clients);
        }

    }
}
