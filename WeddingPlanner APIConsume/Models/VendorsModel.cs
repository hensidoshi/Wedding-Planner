using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class VendorsModel
    {
        public int? VendorID { get; set; }

        [Required(ErrorMessage = "Please enter the vendor name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Vendor Name must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Vendor Name must contain only letters and spaces.")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Please enter the category.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Category must contain only letters and spaces.")]
        public string Category { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter the contact number.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter the email address.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters.")]
        [RegularExpression("^[A-Za-z0-9,.' ]*$", ErrorMessage = "Address must contain only letters, numbers, commas, periods, apostrophes, and spaces.")]
        public string Address { get; set; }
    }
}
