using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class GuestsModel
    {
        public int? GuestID { get; set; }

        [Required(ErrorMessage = "Please enter wedding ID")]
        public int WeddingID { get; set; }

        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter the guest name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Guest name must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Guest name must contain only letters and spaces.")]
        public string GuestName { get; set; }

        [Required(ErrorMessage = "Please enter contact number.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Please enter RSVP status.")]
        [RegularExpression("^(Accepted|Declined|Pending)$", ErrorMessage = "RSVP status must be 'Accepted', 'Declined', or 'Pending'.")]
        public string RSVPStatus { get; set; }

        [Required(ErrorMessage = "Please enter meal preference.")]
        [RegularExpression("^(Vegetarian|Non-Vegetarian|Vegan|Gluten-Free|Other)$",
            ErrorMessage = "Meal preference must be 'Vegetarian', 'Non-Vegetarian', 'Vegan', 'Gluten-Free', or 'Other'.")]
        public string MealPreference { get; set; }
    }
}
