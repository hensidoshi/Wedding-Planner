using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksRepository _tasksRepository;

        public TasksController(TasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        // This TasksController is used for calling methods from TasksRepository

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _tasksRepository.SelectAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _tasksRepository.SelectByPK(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var isDeleted = _tasksRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertTask([FromBody] TasksModel task)
        {
            if (task == null)
                return BadRequest();

            bool isInserted = _tasksRepository.Insert(task);
            if (isInserted)
                return Ok(new { Message = "Task Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the task");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TasksModel task)
        {
            if (task == null || id != task.TaskID)
                return BadRequest();

            var isUpdated = _tasksRepository.Update(task);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _tasksRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }
    }
}
