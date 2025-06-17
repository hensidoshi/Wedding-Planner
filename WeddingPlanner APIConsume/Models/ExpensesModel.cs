using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeddingPlanner_APIConsume.Models
{
    public class ExpensesModel
    {
        public int? ExpenseID { get; set; }

        [Required(ErrorMessage = "Please enter wedding ID")]
        public int WeddingID { get; set; }

        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage = "Please enter the expense description.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Expense description must be between 5 and 200 characters.")]
        public string ExpenseDescription { get; set; }

        [Required(ErrorMessage = "Please enter the amount.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please enter the date.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
