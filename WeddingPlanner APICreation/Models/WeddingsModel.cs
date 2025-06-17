using System.Runtime.InteropServices;

namespace WeddingPlanner_APICreation.Models
{
    public class WeddingsModel
    {
        public int? WeddingID { get; set; }
        public string Bride { get; set; }
        public string Groom { get; set; }
        public DateTime WeddingDate { get; set; }
        public string WeddingLocation { get; set; }
        public string ImageURL { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal Budget { get; set; }
    }
    public class ClientDropDownModel
    {
        public int ClientID { get; set; }
        public string ClientFullName { get; set; }
    }
}
