using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class CustomersModel
    {
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter the first name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "First name must contain only letters and spaces.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Last name must contain only letters and spaces.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the email address.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the contact number.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters.")]
        [RegularExpression("^[A-Za-z0-9,.' ]*$", ErrorMessage = "Address must contain only letters, numbers, commas, periods, apostrophes, and spaces.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the preferred budget.")]
        [Range(1, double.MaxValue, ErrorMessage = "Preferred budget must be greater than zero.")]
        public decimal PreferredBudget { get; set; }

        [Required(ErrorMessage = "Please enter interested themes.")]
        [StringLength(200, ErrorMessage = "Interested themes must not exceed 200 characters.")]
        public string InterestedThemes { get; set; }

    }
}
