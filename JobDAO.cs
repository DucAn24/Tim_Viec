using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class JobDAO
    {

        DbConnection connection = new DbConnection();
        public bool AddJobList(JobInfor jobInfor, int userId)
        {
            string sqlStr = "INSERT INTO JobList(JobTitle, JobDescription, Category, Price,ImagesJob, PostedBy) VALUES(@JobTitle, @JobDescription, @Category, @Price, @ImagesJob, @UserId)";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@JobTitle", jobInfor.JobTitle);
                command.Parameters.AddWithValue("@JobDescription", jobInfor.JobDescription);
                command.Parameters.AddWithValue("@Category", jobInfor.Category);
                command.Parameters.AddWithValue("@Price", jobInfor.Price);
                command.Parameters.AddWithValue("@ImagesJob", jobInfor.ImageJob);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rowsAffected = connection.ExecuteNonQuery(command);
                connection.Close();

                return rowsAffected > 0;
            }
        }


        public bool AddJobHistory(JobInfor jobInfor, int workerId)
        {
            string sqlStr = "INSERT INTO JobHistory(JobTitle, JobDescription, Category, Price,ImagesJob, Worker_id) VALUES(@JobTitle, @JobDescription, @Category, @Price, @ImagesJob, @Worker_id)";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@JobTitle", jobInfor.JobTitle);
                command.Parameters.AddWithValue("@JobDescription", jobInfor.JobDescription);
                command.Parameters.AddWithValue("@Category", jobInfor.Category);
                command.Parameters.AddWithValue("@Price", jobInfor.Price);
                command.Parameters.AddWithValue("@ImagesJob", jobInfor.ImageJob);
                command.Parameters.AddWithValue("@Worker_id", workerId);

                connection.Open();
                int rowsAffected = connection.ExecuteNonQuery(command);
                connection.Close();

                return rowsAffected > 0;
            }
        }

    }
}
