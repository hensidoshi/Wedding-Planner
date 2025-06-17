using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class ClientsRepository
    {
        private readonly string _connectionString;

        public ClientsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ClientsModel> SelectAllClients()
        {
            var clients = new List<ClientsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new ClientsModel
                    {
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Password = reader["Password"].ToString()
                    });
                }
                return clients;
            }
        }

        public ClientsModel SelectByPK(int clientID)
        {
            ClientsModel client = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    client = new ClientsModel
                    {
                        ClientID = Convert.ToInt32(reader["ClientID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
						ImageURL = reader["ImageURL"].ToString(),
						ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
            }
            return client;
        }

        public bool Delete(int clientID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(ClientsModel client)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
                cmd.Parameters.AddWithValue("@ImageURL", client.ImageURL);
                cmd.Parameters.AddWithValue("@ContactNumber", client.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                cmd.Parameters.AddWithValue("@Password", client.Password);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(ClientsModel client)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Clients_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
				cmd.Parameters.AddWithValue("@ImageURL", client.ImageURL);
				cmd.Parameters.AddWithValue("@ContactNumber", client.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                cmd.Parameters.AddWithValue("@Password", client.Password);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
