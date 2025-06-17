using Microsoft.Data.SqlClient;
using WeddingPlanner_APICreation.Models;
using System.Data;

namespace WeddingPlanner_API.Data
{
    public class TasksRepository
    {
        private readonly string _connectionString;

        public TasksRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<TasksModel> SelectAllTasks()
        {
            var tasks = new List<TasksModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tasks.Add(new TasksModel
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        AssignedTo = reader["AssignedTo"].ToString(),
                        Deadline = Convert.ToDateTime(reader["Deadline"]),
                        Status = reader["Status"].ToString()
                    });
                }
                return tasks;
            }
        }

        public TasksModel SelectByPK(int taskID)
        {
            TasksModel task = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", taskID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    task = new TasksModel
                    {
                        TaskID = Convert.ToInt32(reader["TaskID"]),
                        WeddingID = Convert.ToInt32(reader["WeddingID"]),
                        WeddingDate = Convert.ToDateTime(reader["WeddingDate"]),
                        TaskDescription = reader["TaskDescription"].ToString(),
                        ImageURL = reader["ImageURL"].ToString(),
                        AssignedTo = reader["AssignedTo"].ToString(),
                        Deadline = Convert.ToDateTime(reader["Deadline"]),
                        Status = reader["Status"].ToString()
                    };
                }
            }
            return task;
        }

        public bool Delete(int taskID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", taskID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(TasksModel task)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@WeddingID", task.WeddingID);
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@ImageURL",task.ImageURL);
                cmd.Parameters.AddWithValue("@AssignedTo", task.AssignedTo);
                cmd.Parameters.AddWithValue("@Deadline", task.Deadline);
                cmd.Parameters.AddWithValue("@Status", task.Status);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(TasksModel task)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Tasks_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TaskID", task.TaskID);
                cmd.Parameters.AddWithValue("@WeddingID", task.WeddingID);
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@ImageURL", task.ImageURL);
                cmd.Parameters.AddWithValue("@AssignedTo", task.AssignedTo);
                cmd.Parameters.AddWithValue("@Deadline", task.Deadline);
                cmd.Parameters.AddWithValue("@Status", task.Status);
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
