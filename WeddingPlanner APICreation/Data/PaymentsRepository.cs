using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class PaymentsRepository
    {
        private readonly string _connectionString;

        public PaymentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<PaymentsModel> SelectAllPayments()
        {
            var payments = new List<PaymentsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Payments_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    payments.Add(new PaymentsModel
                    {
                        PaymentID = Convert.ToInt32(reader["PaymentID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"].ToString(),
                        AmountPaid = Convert.ToDecimal(reader["AmountPaid"]),
                        PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                        PaymentMethod = reader["PaymentMethod"].ToString()
                    });
                }
                return payments;
            }
        }

        public PaymentsModel SelectByPK(int paymentID)
        {
            PaymentsModel payment = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Payments_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    payment = new PaymentsModel
                    {
                        PaymentID = Convert.ToInt32(reader["PaymentID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"].ToString(),
                        AmountPaid = Convert.ToDecimal(reader["AmountPaid"]),
                        PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                        PaymentMethod = reader["PaymentMethod"].ToString()
                    };
                }
            }
            return payment;
        }

        public bool Delete(int paymentID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Payments_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(PaymentsModel payment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Payments_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", payment.WeddingID);
                cmd.Parameters.AddWithValue("@VendorID", payment.VendorID);
                cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(PaymentsModel payment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Payments_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                cmd.Parameters.AddWithValue("@WeddingID", payment.WeddingID);
                cmd.Parameters.AddWithValue("@VendorID", payment.VendorID);
                cmd.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
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
        public IEnumerable<VendorDropDownModel> GetVendors()
        {
            var vendors = new List<VendorDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Vendors_Dropdown", conn) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    vendors.Add(new VendorDropDownModel
                    {
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"].ToString(), 
                    });
                }
            }
            return vendors;
        }

    }
}
