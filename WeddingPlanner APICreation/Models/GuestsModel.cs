namespace WeddingPlanner_APICreation.Models
{
    public class GuestsModel
    {
        public int? GuestID { get; set; }
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
        public string GuestName { get; set; }
        public string ContactNumber { get; set; }
        public string RSVPStatus { get; set; }
        public string MealPreference { get; set; }
    }
}
