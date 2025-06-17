using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class VendorBookingsModel
    {
        public int? BookingID { get; set; }

        [Required(ErrorMessage = "Please enter wedding ID")]
        public int WeddingID { get; set; }

        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter vendor ID")]
        public int VendorID { get; set; }

        public string? VendorName { get; set; }

        [Required(ErrorMessage = "Please enter the service cost.")]
        [Range(1, double.MaxValue, ErrorMessage = "Service Cost must be greater than zero.")]
        public decimal ServiceCost { get; set; }

        [Required(ErrorMessage = "Please enter the booking date.")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Please enter the remarks.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Remarks must be between 5 and 500 characters.")]
        public string Remarks { get; set; }
    }
}
