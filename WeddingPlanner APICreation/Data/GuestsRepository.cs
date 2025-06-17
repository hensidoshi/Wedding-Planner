using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class GuestsRepository
    {
        private readonly string _connectionString;

        public GuestsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<GuestsModel> SelectAllGuests()
        {
            var guests = new List<GuestsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Guests_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    guests.Add(new GuestsModel
                    {
                        GuestID = Convert.ToInt32(reader["GuestID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        GuestName = reader["GuestName"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        RSVPStatus = reader["RSVPStatus"].ToString(),
                        MealPreference = reader["MealPreference"].ToString()
                    });
                }
                return guests;
            }
        }

        public GuestsModel SelectByPK(int guestID)
        {
            GuestsModel guest = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Guests_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@GuestID", guestID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    guest = new GuestsModel
                    {
                        GuestID = reader["GuestID"] as int?,
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        GuestName = reader["GuestName"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        RSVPStatus = reader["RSVPStatus"].ToString(),
                        MealPreference = reader["MealPreference"].ToString()
                    };
                }
            }
            return guest;
        }

        public bool Delete(int guestID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Guests_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@GuestID", guestID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(GuestsModel guest)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Guests_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", guest.WeddingID);
                cmd.Parameters.AddWithValue("@GuestName", guest.GuestName);
                cmd.Parameters.AddWithValue("@ContactNumber", guest.ContactNumber);
                cmd.Parameters.AddWithValue("@RSVPStatus", guest.RSVPStatus);
                cmd.Parameters.AddWithValue("@MealPreference", guest.MealPreference);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(GuestsModel guest)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Guests_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@GuestID", guest.GuestID);
                cmd.Parameters.AddWithValue("@WeddingID", guest.WeddingID);
                cmd.Parameters.AddWithValue("@GuestName", guest.GuestName);
                cmd.Parameters.AddWithValue("@ContactNumber", guest.ContactNumber);
                cmd.Parameters.AddWithValue("@RSVPStatus", guest.RSVPStatus);
                cmd.Parameters.AddWithValue("@MealPreference", guest.MealPreference);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public IEnumerable<WeddingDropDownModel> GetWeddings()
        {
            var weddings = new List<WeddingDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_Dropdown", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    weddings.Add(new WeddingDropDownModel
                    {
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                    });
                }
            }
            return weddings;
        }
    }
}
