using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class WeddingsRepository
    {
        private readonly string _connectionString;

        public WeddingsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<WeddingsModel> SelectAllWeddings()
        {
            var weddings = new List<WeddingsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    weddings.Add(new WeddingsModel
                    {
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        Bride = reader["Bride"].ToString(),
                        Groom = reader["Groom"].ToString(),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        WeddingLocation = reader["WeddingLocation"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        NumberOfGuests = Convert.ToInt32(reader["NumberOfGuests"]),
                        Budget = Convert.ToDecimal(reader["Budget"])
                    });
                }
                return weddings;
            }
        }

        public WeddingsModel SelectByPK(int weddingID)
        {
            WeddingsModel wedding = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", weddingID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wedding = new WeddingsModel
                    {
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        Bride = reader["Bride"].ToString(),
                        Groom = reader["Groom"].ToString(),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        WeddingLocation = reader["WeddingLocation"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        NumberOfGuests = Convert.ToInt32(reader["NumberOfGuests"]),
                        Budget = Convert.ToDecimal(reader["Budget"])
                    };
                }
            }
            return wedding;
        }

        public bool Delete(int weddingID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", weddingID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(WeddingsModel wedding)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingDate", wedding.WeddingDate);
                cmd.Parameters.AddWithValue("@Bride", wedding.Bride);
                cmd.Parameters.AddWithValue("@Groom", wedding.Groom);
                cmd.Parameters.AddWithValue("@WeddingLocation", wedding.WeddingLocation);
                cmd.Parameters.AddWithValue("@ImageURL", wedding.ImageURL);
                cmd.Parameters.AddWithValue("@NumberOfGuests", wedding.NumberOfGuests);
                cmd.Parameters.AddWithValue("@Budget", wedding.Budget);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(WeddingsModel wedding)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Weddings_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", wedding.WeddingID);
                cmd.Parameters.AddWithValue("@Bride", wedding.Bride);
                cmd.Parameters.AddWithValue("@Groom", wedding.Groom);
                cmd.Parameters.AddWithValue("@WeddingDate", wedding.WeddingDate);
                cmd.Parameters.AddWithValue("@WeddingLocation", wedding.WeddingLocation);
                cmd.Parameters.AddWithValue("@ImageURL", wedding.ImageURL);
                cmd.Parameters.AddWithValue("@NumberOfGuests", wedding.NumberOfGuests);
                cmd.Parameters.AddWithValue("@Budget", wedding.Budget);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public IEnumerable<ClientDropDownModel> GetClients()
        {
            var clients = new List<ClientDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_Dropdown", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clients.Add(new ClientDropDownModel
                    {
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        ClientFullName = reader["ClientFullName"].ToString() // Access the concatenated ClientFullName
                    });
                }
            }

            return clients;
        }
    }
}
