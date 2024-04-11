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
        public bool AddJob(JobInfor jobInfor, int userId)
        {
            string sqlStr = "INSERT INTO JobList(JobTitle, JobDescription, Category, Price, PostedBy) VALUES(@JobTitle, @JobDescription, @Category, @MinPrice, @MaxPrice, @PayType, @UserId)";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@JobTitle", jobInfor.JobTitle);
                command.Parameters.AddWithValue("@JobDescription", jobInfor.JobDescription);
                command.Parameters.AddWithValue("@Category", jobInfor.Category);
                command.Parameters.AddWithValue("@MPrice", jobInfor.Price);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rowsAffected = connection.ExecuteNonQuery(command);
                connection.Close();

                return rowsAffected > 0;
            }
        }

    }
}
