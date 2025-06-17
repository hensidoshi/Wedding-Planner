using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class CustomersRepository
    {
        private readonly string _connectionString;

        public CustomersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CustomersModel> SelectAllCustomers()
        {
            var customers = new List<CustomersModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customers_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new CustomersModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        PreferredBudget = Convert.ToDecimal(reader["PreferredBudget"]),
                        InterestedThemes = reader["InterestedThemes"].ToString()
                    });
                }
                return customers;
            }
        }

        public CustomersModel SelectByPK(int customerID)
        {
            CustomersModel customer = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customers_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new CustomersModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        PreferredBudget = Convert.ToDecimal(reader["PreferredBudget"]),
                        InterestedThemes = reader["InterestedThemes"].ToString()
                    };
                }
            }
            return customer;
        }

        public bool Delete(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customers_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(CustomersModel customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customers_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@PreferredBudget", customer.PreferredBudget);
                cmd.Parameters.AddWithValue("@InterestedThemes", customer.InterestedThemes);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(CustomersModel customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customers_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@PreferredBudget", customer.PreferredBudget);
                cmd.Parameters.AddWithValue("@InterestedThemes", customer.InterestedThemes);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
