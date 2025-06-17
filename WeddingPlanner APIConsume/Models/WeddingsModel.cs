using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class WeddingsModel
    {
        public int? WeddingID { get; set; }

        [Required(ErrorMessage = "Please enter bride name.")]
        public string Bride { get; set; }

        [Required(ErrorMessage = "Please enter groom name.")]
        public string Groom { get; set; }

        [Required(ErrorMessage = "Please enter wedding date.")]
        [DataType(DataType.Date)]
        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter the wedding location.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Wedding location must be between 3 and 100 characters.")]
        [RegularExpression("^[A-Za-z0-9,.' ]*$", ErrorMessage = "Wedding location must contain only letters, numbers, commas, periods, apostrophes, and spaces.")]
        public string WeddingLocation { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter the number of guests.")]
        [Range(1, 5000, ErrorMessage = "Number of guests must be between 1 and 5000.")]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = "Please enter the budget.")]
        [Range(1, double.MaxValue, ErrorMessage = "Budget must be greater than zero.")]
        public decimal Budget { get; set; }
    }
    public class ClientDropDownModel
    {
        public int ClientID { get; set; }
        public string ClientFullName { get; set; }
    }
}
