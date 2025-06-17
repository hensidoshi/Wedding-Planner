using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class VendorBookingsRepository
    {
        private readonly string _connectionString;

        public VendorBookingsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<VendorBookingsModel> SelectAllVendorBookings()
        {
            var bookings = new List<VendorBookingsModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_VendorBookings_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookings.Add(new VendorBookingsModel
                    {
                        BookingID = Convert.ToInt32(reader["BookingID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"]?.ToString(),
                        ServiceCost = Convert.ToDecimal(reader["ServiceCost"]),
                        BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                        Remarks = reader["Remarks"]?.ToString()
                    });
                }
                return bookings;
            }
        }

        public VendorBookingsModel SelectByPK(int bookingID)
        {
            VendorBookingsModel booking = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_VendorBookings_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    booking = new VendorBookingsModel
                    {
                        BookingID = Convert.ToInt32(reader["BookingID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        VendorID = Convert.ToInt32(reader["VendorID"]),
                        VendorName = reader["VendorName"]?.ToString(),
                        ServiceCost = Convert.ToDecimal(reader["ServiceCost"]),
                        BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                        Remarks = reader["Remarks"]?.ToString()
                    };
                }
            }
            return booking;
        }

        public bool Delete(int bookingID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_VendorBookings_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(VendorBookingsModel booking)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_VendorBookings_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", booking.WeddingID);
                cmd.Parameters.AddWithValue("@VendorID", booking.VendorID);
                cmd.Parameters.AddWithValue("@ServiceCost", booking.ServiceCost);
                cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                cmd.Parameters.AddWithValue("@Remarks", booking.Remarks ?? (object)DBNull.Value);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(VendorBookingsModel booking)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_VendorBookings_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@WeddingID", booking.WeddingID);
                cmd.Parameters.AddWithValue("@VendorID", booking.VendorID);
                cmd.Parameters.AddWithValue("@ServiceCost", booking.ServiceCost);
                cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                cmd.Parameters.AddWithValue("@Remarks", booking.Remarks ?? (object)DBNull.Value);
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
