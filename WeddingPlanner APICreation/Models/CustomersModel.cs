namespace WeddingPlanner_APICreation.Models
{
    public class CustomersModel
    {
        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public decimal PreferredBudget { get; set; }
        public string InterestedThemes { get; set; }

    }
}
