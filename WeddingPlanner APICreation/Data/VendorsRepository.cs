using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class VendorsRepository
    {
        private readonly string _connectionString;

        public VendorsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<VendorsModel> SelectAllVendors()
        {
            var vendors = new List<VendorsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vendors.Add(new VendorsModel
                    {
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"].ToString(),
                        Category = reader["Category"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
                return vendors;
            }
        }

        public VendorsModel SelectByPK(int vendorID)
        {
            VendorsModel vendor = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorID", vendorID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    vendor = new VendorsModel
                    {
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"].ToString(),
                        Category = reader["Category"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        ContactNumber = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
            }
            return vendor;
        }

        public bool Delete(int vendorID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorID", vendorID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(VendorsModel vendor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                cmd.Parameters.AddWithValue("@Category", vendor.Category);
                cmd.Parameters.AddWithValue("@ImageURL", vendor.ImageURL);
                cmd.Parameters.AddWithValue("@ContactNumber", vendor.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", vendor.Email);
                cmd.Parameters.AddWithValue("@Address", vendor.Address);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(VendorsModel vendor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorID", vendor.VendorID);
                cmd.Parameters.AddWithValue("@VendorName", vendor.VendorName);
                cmd.Parameters.AddWithValue("@Category", vendor.Category);
                cmd.Parameters.AddWithValue("@ImageURL",vendor.ImageURL);   
                cmd.Parameters.AddWithValue("@ContactNumber", vendor.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", vendor.Email);
                cmd.Parameters.AddWithValue("@Address", vendor.Address);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
