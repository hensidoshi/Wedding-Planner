namespace WeddingPlanner_APICreation.Models
{
    public class TasksModel
    {
        public int? TaskID { get; set; }
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
        public string TaskDescription { get; set; }
        public string ImageURL { get; set; }
        public string AssignedTo { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
    }
}
