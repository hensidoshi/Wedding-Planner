namespace WeddingPlanner_APICreation.Models
{
    public class FeedbacksModel
    {
        public int? FeedbackID { get; set; }
        public int ClientID { get; set; }
        public string? ClientFullName { get; set; }
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
