using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WeddingPlanner_API.Data
{
    public class UsersRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        // Constructor now also injects IConfiguration
        public UsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        public IEnumerable<UsersModel> SelectAllUsers()
        {
            var users = new List<UsersModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Users_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UsersModel
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
                return users;
            }
        }

        public UsersModel SelectByPK(int userID)
        {
            UsersModel user = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Users_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", userID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new UsersModel
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                }
            }
            return user;
        }

        public bool Delete(int userID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Users_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", userID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(UsersModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Users_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(UsersModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Users_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        #region Signup
        public bool Signup(UsersModel userModel, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_User_SignUp", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserName", userModel.UserName);
                cmd.Parameters.AddWithValue("@Password", userModel.Password);
                cmd.Parameters.AddWithValue("@Email", userModel.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", userModel.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", userModel.Address);
                cmd.Parameters.AddWithValue("@Role", userModel.Role);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50000) // Custom RAISERROR
                    {
                        errorMessage = ex.Message;
                    }
                    else
                    {
                        errorMessage = "An error occurred while inserting the user.";
                    }
                    return false;
                }
            }
        }
        #endregion

        #region Login
        public string Login(LoginModel loginModel, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("PR_User_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", loginModel.UserName);
                    cmd.Parameters.AddWithValue("@Password", loginModel.Password);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // If login is successful
                        {
                            var user = new UsersModel
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                UserName = reader["UserName"].ToString(),
                                Role = reader["Role"].ToString()
                            };

                            return GenerateJwtToken(user); // Fixed variable name to 'user'
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message; // Capture error message from stored procedure
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = "An unexpected error occurred. Please try again.";
                return null;
            }

            errorMessage = "Invalid username or password.";
            return null;
        }

        private string GenerateJwtToken(UsersModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("UserID", user.UserID.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
