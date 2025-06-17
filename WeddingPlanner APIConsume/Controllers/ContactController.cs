using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingPlanner_APIConsume.Models;

public class ContactController : Controller
{
	private readonly ApplicationDbContext _context;

	public ContactController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpPost]
	public async Task<IActionResult> SubmitForm([FromBody] ContactFormModel model)
	{
		if (ModelState.IsValid)
		{
			_context.ContactForms.Add(model);
			await _context.SaveChangesAsync();
			return Json(new { success = true });
		}
		return Json(new { success = false, message = "Invalid data" });
	}
}
