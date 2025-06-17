using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class TasksModel
    {
        public int? TaskID { get; set; }

        [Required(ErrorMessage = "Please enter wedding ID")]
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter task description.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Task description must be between 5 and 200 characters.")]
        public string TaskDescription { get; set; }

        [Required(ErrorMessage = "Please enter Image URL.")]
        [Url(ErrorMessage = "Please enter a valid Image URL.")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter the assigned to.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Assigned To name must be between 3 and 100 characters.")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Please enter deadline.")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Please enter the status.")]
        [RegularExpression("^(Pending|In Progress|Completed)$", ErrorMessage = "Status must be 'Pending', 'In Progress', or 'Completed'.")]
        public string Status { get; set; }
    }
}
