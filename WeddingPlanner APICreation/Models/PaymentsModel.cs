namespace WeddingPlanner_APICreation.Models
{
    public class PaymentsModel
    {
        public int? PaymentID { get; set; }
        public int WeddingID { get; set; }  
        public DateTime WeddingDate { get; set; }
        public int VendorID { get; set; }
        public string? VendorName { get; set; } 
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
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
