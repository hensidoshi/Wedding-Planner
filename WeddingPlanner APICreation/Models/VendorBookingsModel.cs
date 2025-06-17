namespace WeddingPlanner_APICreation.Models
{
    public class VendorBookingsModel
    {
        public int? BookingID { get; set; }
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
        public int VendorID { get; set; }
        public string? VendorName { get; set; }  
        public decimal ServiceCost { get; set; }
        public DateTime BookingDate { get; set; }
        public string Remarks { get; set; }
    }
}
