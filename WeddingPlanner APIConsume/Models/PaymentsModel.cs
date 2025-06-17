using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class PaymentsModel
    {
        public int? PaymentID { get; set; }

        [Required(ErrorMessage = "Please enter wedding ID")]
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter vendor ID")]
        public int VendorID { get; set; }
        public string? VendorName { get; set; }

        [Required(ErrorMessage = "Please enter the amount paid.")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Please enter the payment date.")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "please enter the payment method.")]
        [RegularExpression("^(Cash|Credit Card|Debit Card|Bank Transfer|Online Payment)$",
                    ErrorMessage = "Payment Method must be 'Cash', 'Credit Card', 'Debit Card', 'Bank Transfer', or 'Online Payment'.")]
        public string PaymentMethod { get; set; }
    }
    public class WeddingDropDownModel
    {
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
    }
    public class VendorDropDownModel
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
    }
}
