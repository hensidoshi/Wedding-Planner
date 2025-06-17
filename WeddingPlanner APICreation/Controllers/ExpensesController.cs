using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesRepository _expensesRepository;

        public ExpensesController(ExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        // Get all expenses
        [HttpGet]
        public IActionResult GetAllExpenses()
        {
            var expenses = _expensesRepository.SelectAllExpenses();
            return Ok(expenses);
        }

        // Get expense by ID
        [HttpGet("{id}")]
        public IActionResult GetExpenseById(int id)
        {
            var expense = _expensesRepository.SelectByPK(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        // Delete an expense
        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var isDeleted = _expensesRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Insert a new expense
        [HttpPost]
        public IActionResult InsertExpense([FromBody] ExpensesModel expense)
        {
            if (expense == null)
                return BadRequest();

            bool isInserted = _expensesRepository.Insert(expense);
            if (isInserted)
                return Ok(new { Message = "Expense Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the expense");
        }

        // Update an expense
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, [FromBody] ExpensesModel expense)
        {
            if (expense == null || id != expense.ExpenseID)
                return BadRequest();

            var isUpdated = _expensesRepository.Update(expense);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpGet("weddings")]
        public IActionResult GetWeddings()
        {
            var weddings = _expensesRepository.GetWeddings();
            if (!weddings.Any())
                return NotFound("No weddings found.");

            return Ok(weddings);
        }
    }
}
