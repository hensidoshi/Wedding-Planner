using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class FeedbacksRepository
    {
        private readonly string _connectionString;

        public FeedbacksRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Select all feedbacks
        public IEnumerable<FeedbacksModel> SelectAllFeedbacks()
        {
            var feedbacks = new List<FeedbacksModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Feedbacks_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    feedbacks.Add(new FeedbacksModel
                    {
                        FeedbackID = Convert.ToInt32(reader["FeedbackID"]),
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        ClientFullName = reader["ClientFullName"].ToString(),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        Rating = Convert.ToInt32(reader["Rating"]),
                        Comments = reader["Comments"].ToString(),
                        FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"]),
                    });
                }
                return feedbacks;
            }
        }

        // Select feedback by primary key (ID)
        public FeedbacksModel SelectByPK(int feedbackID)
        {
            FeedbacksModel feedback = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Feedbacks_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    feedback = new FeedbacksModel
                    {
                        FeedbackID = Convert.ToInt32(reader["FeedbackID"]),
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        ClientFullName = reader["ClientFullName"].ToString(),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        Rating = Convert.ToInt32(reader["Rating"]),
                        Comments = reader["Comments"].ToString(),
                        FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"]),
                    };
                }
            }
            return feedback;
        }

        // Delete feedback by ID
        public bool Delete(int feedbackID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Feedbacks_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Insert a new feedback
        public bool Insert(FeedbacksModel feedback)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Feedbacks_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", feedback.ClientID);
                cmd.Parameters.AddWithValue("@WeddingID", feedback.WeddingID);
                cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
                cmd.Parameters.AddWithValue("@FeedbackDate", feedback.FeedbackDate);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Update an existing feedback
        public bool Update(FeedbacksModel feedback)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Feedbacks_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FeedbackID", feedback.FeedbackID);
                cmd.Parameters.AddWithValue("@ClientID", feedback.ClientID);
                cmd.Parameters.AddWithValue("@WeddingID", feedback.WeddingID);
                cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
                cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
                cmd.Parameters.AddWithValue("@FeedbackDate", feedback.FeedbackDate);
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
                        ClientFullName = reader["ClientFullName"].ToString()
                    });
                }
            }

            return clients;
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
