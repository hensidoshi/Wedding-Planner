using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner_APIConsume.Models
{
    public class FeedbacksModel
    {
            public int? FeedbackID { get; set; }

            [Required(ErrorMessage = "Please enter client ID")]
            public int ClientID { get; set; }

            public string? ClientFullName { get; set; }
            [Required(ErrorMessage = "Please enter wedding ID")]
            public int WeddingID { get; set; }

            public DateTime WeddingDate { get; set; }

            [Required(ErrorMessage = "Please enter a rating.")]
            [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
            public int Rating { get; set; }

            [Required(ErrorMessage = "Please enter comments.")]
            [StringLength(500, MinimumLength = 5, ErrorMessage = "Comments must be between 5 and 500 characters.")]
            public string Comments { get; set; }

            [Required(ErrorMessage = "Please enter the feedback date.")]
            [DataType(DataType.Date)]
            public DateTime FeedbackDate { get; set; }
    }
}
