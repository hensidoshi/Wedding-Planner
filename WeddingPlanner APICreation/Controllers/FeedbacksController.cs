using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbacksRepository _feedbackRepository;

        public FeedbacksController(FeedbacksRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // Get all feedbacks
        [HttpGet]
        public IActionResult GetAllFeedbacks()
        {
            var feedbacks = _feedbackRepository.SelectAllFeedbacks();
            return Ok(feedbacks);
        }

        // Get feedback by ID
        [HttpGet("{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            var feedback = _feedbackRepository.SelectByPK(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        // Delete feedback by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteFeedback(int id)
        {
            var isDeleted = _feedbackRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Insert a new feedback
        [HttpPost]
        public IActionResult InsertFeedback([FromBody] FeedbacksModel feedback)
        {
            if (feedback == null)
                return BadRequest();

            bool isInserted = _feedbackRepository.Insert(feedback);
            if (isInserted)
                return Ok(new { Message = "Feedback Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the feedback");
        }

        // Update feedback by ID
        [HttpPut("{id}")]
        public IActionResult UpdateFeedback(int id, [FromBody] FeedbacksModel feedback)
        {
            if (feedback == null || id != feedback.FeedbackID)
                return BadRequest();

            var isUpdated = _feedbackRepository.Update(feedback);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("clients")]
        public IActionResult GetClients()
        {
            var clients = _feedbackRepository.GetClients();
            if (!clients.Any())
                return NotFound("No clients found.");

            return Ok(clients);
        }

        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _feedbackRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }
    }
}
