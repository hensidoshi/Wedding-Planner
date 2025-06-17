namespace WeddingPlanner_APIConsume.Models
{
    public class WeddingBooking
    {
        public int? WeddingID { get; set; }
        public string CustomerName { get; set; }
        public string Venue { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
    }
}
