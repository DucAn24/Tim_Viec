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

        public List<JobInfor> GetJobsByCategory(string category)
        {
            List<JobInfor> jobs = new List<JobInfor>();

            string query = @"
                        SELECT J.JobTitle,
                                J.JobDescription,
                                J.Price,
                                J.ImagesJob,
                                J.job_id
                        FROM JobList J
                        WHERE J.Category = @Category
                    ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@Category", category);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    JobInfor job = new JobInfor(
                        reader["JobTitle"].ToString(),
                        reader["JobDescription"].ToString(),
                        category,
                        reader["Price"].ToString(),
                        reader["ImagesJob"] as string
                    )
                    {
                        JobId = Convert.ToInt32(reader["job_id"]) // Add this line
                    };

                    jobs.Add(job);
                }

                connection.Close();
            }

            return jobs;
        }

        public List<JobInfor> SearchJobs(string jobTitle, string orderByPrice)
        {
            List<JobInfor> jobs = new List<JobInfor>();

            string query = @"
                            SELECT J.JobTitle, J.JobDescription, J.Price, J.ImagesJob, J.job_id
                            FROM JobList J
                            WHERE J.JobTitle LIKE @JobTitle
                        ";

            if (!string.IsNullOrEmpty(orderByPrice))
            {
                query += $" ORDER BY J.Price {orderByPrice}";
            }

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@JobTitle", "%" + jobTitle + "%");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    JobInfor job = new JobInfor(
                        reader["JobTitle"].ToString(),
                        reader["JobDescription"].ToString(),
                        "", // Category is not selected in the query
                        reader["Price"].ToString(),
                        reader["ImagesJob"] as string
                    )
                    {
                        JobId = Convert.ToInt32(reader["job_id"])
                    };

                    jobs.Add(job);
                }

                connection.Close();
            }

            return jobs;
        }

        public List<JobInfor> LoadWorkHistory(int workerId)
        {
            List<JobInfor> jobs = new List<JobInfor>();

            string query = @"
                    SELECT J.JobTitle,
                            J.JobDescription,
                            J.Price,
                            J.Category,
                            J.ImagesJob
                    FROM JobHistory J
                    WHERE J.Worker_id = @workerId
                    ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@workerId", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string jobTitle = reader["JobTitle"].ToString();
                    string jobDescription = reader["JobDescription"].ToString();
                    string price = reader["Price"].ToString();
                    string category = reader["Category"].ToString();
                    string imagesJob = reader["ImagesJob"].ToString();

                    JobInfor job = new JobInfor(jobTitle, jobDescription, category, price, imagesJob);
                    jobs.Add(job);
                }

                connection.Close();
            }

            return jobs;
        }

        public List<JobInfor> LoadWorkDone(int workerId)
        {
            List<JobInfor> jobs = new List<JobInfor>();

            string query = @"
                    SELECT J.JobTitle,
                            J.JobDescription,
                            J.Price,
                            J.Category,
                            J.ImagesJob
                    FROM JobHistory J
                    WHERE J.Worker_id = @workerId
                    ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@workerId", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string jobTitle = reader["JobTitle"].ToString();
                    string jobDescription = reader["JobDescription"].ToString();
                    string price = reader["Price"].ToString();
                    string category = reader["Category"].ToString();
                    string imagesJob = reader["ImagesJob"].ToString();

                    JobInfor job = new JobInfor(jobTitle, jobDescription, category, price, imagesJob);
                    jobs.Add(job);
                }

                connection.Close();
            }

            return jobs;
        }










    }
}
