namespace WeddingPlanner_APICreation.Models
{

    public class WeddingGuest
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string Country { get; set; }
        public string RSVPStatus { get; set; }  // "Confirmed", "Pending", "Declined"
        public string GiftType { get; set; }    // "Cash", "Gift Card", "Item"
        public string PaymentStatus { get; set; } // "Paid", "Pending"
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }

}
