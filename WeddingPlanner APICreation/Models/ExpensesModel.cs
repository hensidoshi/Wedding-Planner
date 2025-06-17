namespace WeddingPlanner_APICreation.Models
{
    public class ExpensesModel
    {
        public int? ExpenseID { get; set; }
        public int WeddingID { get; set; }
        public DateTime WeddingDate { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
