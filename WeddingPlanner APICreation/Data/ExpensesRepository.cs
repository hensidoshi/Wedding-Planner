using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class ExpensesRepository
    {
        private readonly string _connectionString;

        public ExpensesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Get all expenses
        public IEnumerable<ExpensesModel> SelectAllExpenses()
        {
            var expenses = new List<ExpensesModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Expenses_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    expenses.Add(new ExpensesModel
                    {
                        ExpenseID = Convert.ToInt32(reader["ExpenseID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        ExpenseDescription = reader["ExpenseDescription"].ToString(),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        Date = Convert.ToDateTime(reader["Date"])
                    });
                }
                return expenses;
            }
        }

        // Get expense by ID
        public ExpensesModel SelectByPK(int expenseID)
        {
            ExpensesModel expense = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Expenses_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ExpenseID", expenseID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    expense = new ExpensesModel
                    {
                        ExpenseID = reader["ExpenseID"] as int?,
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        ExpenseDescription = reader["ExpenseDescription"].ToString(),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        Date = Convert.ToDateTime(reader["Date"])
                    };
                }
            }
            return expense;
        }

        // Delete an expense
        public bool Delete(int expenseID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Expenses_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ExpenseID", expenseID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Insert a new expense
        public bool Insert(ExpensesModel expense)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Expenses_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", expense.WeddingID);
                cmd.Parameters.AddWithValue("@ExpenseDescription", expense.ExpenseDescription);
                cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                cmd.Parameters.AddWithValue("@Date", expense.Date);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Update an expense
        public bool Update(ExpensesModel expense)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Expenses_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ExpenseID", expense.ExpenseID);
                cmd.Parameters.AddWithValue("@WeddingID", expense.WeddingID);
                cmd.Parameters.AddWithValue("@ExpenseDescription", expense.ExpenseDescription);
                cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                cmd.Parameters.AddWithValue("@Date", expense.Date);
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
