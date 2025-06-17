using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
	public class ContactFormModel
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		public int Guest { get; set; }

		[Required]
		public string Event { get; set; }

		[Required]
		public string Message { get; set; }
	}
}
