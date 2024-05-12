using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class WorkerDAO
    {
        DbConnection connection = new DbConnection();
        public bool UpdateWorkerInformation(Worker worker, int userId)
        {
            try
            {
                string sqlStrUsers = "UPDATE Users SET Name = @Name, Email = @Email, DateOfBirth = @DateOfBirth, ImagePath = @ImagePath, PhoneNumber = @Phone, Address = @Address, Gender = @Gender WHERE user_id = @UserId";
                string sqlStrWorker = "UPDATE Worker SET Bio = @Bio, Skills = @Skills, Category = @Category, Salary = @Salary WHERE user_id = @UserId";
                string sqlStrInsertWorker = "INSERT INTO Worker (user_id, Bio, Skills, Category, Salary) VALUES (@UserId, @Bio, @Skills, @Category, @Salary)";

                using (SqlCommand command = new SqlCommand(sqlStrUsers, connection.Connection))
                {
                    command.Parameters.AddWithValue("@Name", worker.Name);
                    command.Parameters.AddWithValue("@Email", worker.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", worker.DateOfBirth.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@ImagePath", worker.ImagePath);
                    command.Parameters.AddWithValue("@Phone", worker.Phone);
                    command.Parameters.AddWithValue("@Address", worker.Address);
                    command.Parameters.AddWithValue("@Gender", worker.Gender);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        using (SqlCommand commandWorker = new SqlCommand(sqlStrWorker, connection.Connection))
                        {
                            commandWorker.Parameters.AddWithValue("@Bio", worker.Bio);
                            commandWorker.Parameters.AddWithValue("@Skills", worker.Skills);
                            commandWorker.Parameters.AddWithValue("@Category", worker.Category);
                            commandWorker.Parameters.AddWithValue("@Salary", worker.Salary);
                            commandWorker.Parameters.AddWithValue("@UserId", userId);

                            connection.Open();
                            rowsAffected = commandWorker.ExecuteNonQuery();
                            connection.Close();

                            // If no rows were affected, insert a new record
                            if (rowsAffected == 0)
                            {
                                using (SqlCommand insertCommand = new SqlCommand(sqlStrInsertWorker, connection.Connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Bio", worker.Bio);
                                    insertCommand.Parameters.AddWithValue("@Skills", worker.Skills);
                                    insertCommand.Parameters.AddWithValue("@Category", worker.Category);
                                    insertCommand.Parameters.AddWithValue("@Salary", worker.Salary);
                                    insertCommand.Parameters.AddWithValue("@UserId", userId);

                                    connection.Open();
                                    rowsAffected = insertCommand.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                        }
                    }

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
                return false;
            }
        }


        public List<Worker> GetWorkersByCategory(string category)
        {
            List<Worker> workers = new List<Worker>();

            string query = @"
                            SELECT  W.Worker_id,
                                    U.Name,
                                    U.Email,
                                    U.ImagePath,
                                    U.DateOfBirth,
                                    W.Bio,
                                    W.Skills,
                                    W.Salary 
                            FROM Users U
                            JOIN Worker W
                            ON U.user_id = w.user_id
                            WHERE W.Category = @Category
                        ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@Category", category);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Worker worker = new Worker(
                        reader["Name"].ToString(),
                        reader["Email"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"]),
                        reader["ImagePath"] as string,
                        null, 
                        null, 
                        null, 
                        reader["Bio"].ToString(),
                        reader["Skills"].ToString(),
                        category,
                        reader["Salary"].ToString()
                    )
                    {
                        WorkerId = Convert.ToInt32(reader["Worker_id"]) 
                    };

                    workers.Add(worker);
                }

                connection.Close();
            }

            return workers;
        }

        public List<Worker> SearchWorkers(string skills, string orderByPrice)
        {
            List<Worker> workers = new List<Worker>();

            string query = @"
                        SELECT  W.Worker_id,
                                U.Name,
                                U.Email,
                                U.ImagePath,
                                U.DateOfBirth,
                                W.Bio,
                                W.Skills,
                                W.Salary
                        FROM Users U
                        JOIN Worker W
                        ON U.user_id = w.user_id
                        WHERE W.Skills LIKE @Skills
                    ";

            if (!string.IsNullOrEmpty(orderByPrice))
            {
                query += $" ORDER BY W.Salary {orderByPrice}";
            }

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@Skills", "%" + skills + "%");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Worker worker = new Worker(
                        reader["Name"].ToString(),
                        reader["Email"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"]),
                        reader["ImagePath"] as string,
                        null, 
                        null, 
                        null, 
                        reader["Bio"].ToString(),
                        reader["Skills"].ToString(),
                        null, 
                        reader["Salary"].ToString()
                    )
                    {
                        WorkerId = Convert.ToInt32(reader["Worker_id"]) // Assuming Worker class has a WorkerId property
                    };

                    workers.Add(worker);
                }

                connection.Close();
            }

            return workers;
        }

        public Worker LoadWorkerData(int workerId)
        {
            Worker worker = null;

            string selectQuery = @"
                    SELECT	U.Name, 
                            U.Email,
                            U.Address, 
                            U.PhoneNumber, 
                            U.Address, 
                            U.Gender, 
                            U.DateOfBirth, 
                            U.imagePath,
                            W.Bio,
                            W.Skills,
                            W.Category,
                            W.Salary
                    FROM Users U
                    JOIN Worker W
                    ON U.user_id = W.user_id
                    WHERE worker_id = @Worker_id
                ";

            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection.Connection))
            {
                selectCommand.Parameters.AddWithValue("@Worker_id", workerId);
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string email = reader["Email"].ToString();
                    string address = reader["Address"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    string gender = reader["Gender"].ToString();
                    DateTime dateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : default;
                    string imagePath = reader["ImagePath"].ToString();
                    string bio = reader["Bio"].ToString();
                    string skills = reader["Skills"].ToString();
                    string category = reader["Category"].ToString();
                    string salary = reader["Salary"].ToString();

                    worker = new Worker(name, email, dateOfBirth, imagePath, phoneNumber, address, gender, bio, skills, category, salary);
                }

                connection.Close();
            }

            return worker;
        }

        public Worker LoadInformationWorker(int workerId)
        {
            Worker worker = null;

            string query = @"
                    SELECT  W.Worker_id,
                            U.Name,
                            U.Gender,
                            U.Address,
                            U.PhoneNumber,
                            U.Email,
                            U.ImagePath,
                            W.Salary, 
                            AVG(R.Stars) as AVG_Stars
                    FROM Users U
                    JOIN Worker W ON U.user_id = w.user_id
                    LEFT JOIN Ratings R ON R.Worker_id = W.Worker_id
                    WHERE W.Worker_id = @WorkerId
                    GROUP BY W.Worker_id, U.Name, U.Gender, U.Address, U.PhoneNumber, U.Email, U.ImagePath, W.Salary;
                    ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@WorkerId", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string gender = reader["Gender"].ToString();
                    string address = reader["Address"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    string email = reader["Email"].ToString();
                    string imagePath = reader["ImagePath"].ToString();
                    string salary = reader["Salary"].ToString();
                    double avgStars = reader["AVG_Stars"] != DBNull.Value ? Convert.ToDouble(reader["AVG_Stars"]) : 0;

                    worker = new Worker(name, email, DateTime.MinValue, imagePath, phoneNumber, address, gender, null, null, null, salary)
                    {
                        WorkerId = Convert.ToInt32(reader["Worker_id"]),
                        AvgStars = avgStars
                    };
                }

                connection.Close();
            }

            return worker;
        }
        public bool ApplyForJob(int jobId, int workerId)
        {
            try
            {
                connection.Open();

                string checkQuery = @"
                            SELECT COUNT(*) 
                            FROM Applications 
                            WHERE job_id = @JobId AND Worker_id = @WorkerId
                        ";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection.Connection))
                {
                    checkCommand.Parameters.AddWithValue("@JobId", jobId);
                    checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        string query = @"
                                INSERT INTO Applications (job_id, Worker_id)
                                VALUES (@JobId, @WorkerId)
                            ";

                        using (SqlCommand command = new SqlCommand(query, connection.Connection))
                        {
                            command.Parameters.AddWithValue("@JobId", jobId);
                            command.Parameters.AddWithValue("@WorkerId", workerId);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Ratings> LoadRatingInfo(int workerId)
        {
            List<Ratings> ratingInfo = new List<Ratings>();

            string query = @"
                            SELECT  
                                    R.Comment,
                                    U.Name,
                                    U.ImagePath
                            FROM Worker W 
                            JOIN Ratings R ON W.Worker_id = R.Worker_id 
                            JOIN Users U ON U.user_id = R.user_id
                            WHERE W.Worker_id = @WorkerId
                        ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@WorkerId", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string comment = reader["Comment"].ToString();
                    string name = reader["Name"].ToString();
                    string imagePath = reader["ImagePath"].ToString();

                    Ratings ratings = new Ratings(comment, 0, name, imagePath);
                    ratingInfo.Add(ratings);
                }

                connection.Close();
            }

            return ratingInfo;
        }

        public Dictionary<string, int> GetJobCountPerCategory(int workerId)
        {
            Dictionary<string, int> jobCountPerCategory = new Dictionary<string, int>();

            string query = @"
                            SELECT  
                                Category, 
                                COUNT(*) as JobsInCategory
                            FROM JobHistory
                            WHERE Worker_id = @Worker_id
                            GROUP BY Category;
                        ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@Worker_id", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string category = reader["Category"].ToString();
                    int jobCount = Convert.ToInt32(reader["JobsInCategory"]);

                    jobCountPerCategory.Add(category, jobCount);
                }

                connection.Close();
            }

            return jobCountPerCategory;
        }

        public double GetAverageRating(int workerId)
        {
            double AvgRatings = 0;
            connection.Open();

            string query = @"
                SELECT AVG(Stars) AS AvgRatings
                FROM Ratings
                WHERE Worker_id = @Worker_id
                GROUP BY Worker_id;
            ";

            SqlCommand command = new SqlCommand(query, connection.Connection);

            command.Parameters.AddWithValue("@Worker_id", workerId);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                AvgRatings = (double)result;
            }
            connection.Close();

            return AvgRatings;
        }

        public decimal GetTotalRevenue(int workerId)
        {
            decimal revenue = 0;
            connection.Open();

            string query = @"
                SELECT SUM(Price) as TotalRevenue
                FROM JobHistory
                WHERE Worker_id =  @Worker_id;
    ";

            SqlCommand command = new SqlCommand(query, connection.Connection);

            command.Parameters.AddWithValue("@Worker_id", workerId);

            object result = command.ExecuteScalar();

            if (result != DBNull.Value)
            {
                revenue = (decimal)result;
            }
            connection.Close();

            return revenue;
        }


        public int GetTotalWorkDone(int workerId)
        {
            int totalWorkDone = 0;
            connection.Open();

            string query = @"
                        SELECT COUNT(*) as TotalWorkDone
                        FROM JobHistory
                        WHERE Worker_id = @Worker_id;
            ";

            SqlCommand command = new SqlCommand(query, connection.Connection);

            command.Parameters.AddWithValue("@Worker_id", workerId);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                totalWorkDone = (int)result;
            }
            connection.Close();
            return totalWorkDone;
        }



        public int GetWorkerIdFromUserId(int userId)
        {
            int workerId = -1;

            connection.Open();

            string query = @"
                SELECT W.Worker_id
                FROM Users U
                JOIN Worker W
                ON U.user_id = W.user_id
                WHERE U.user_id = @UserId
            ";

            SqlCommand command = new SqlCommand(query, connection.Connection);

            command.Parameters.AddWithValue("@UserId", userId);

            object result = command.ExecuteScalar();

            if (result != null)
            {
                workerId = (int)result;
            }
            connection.Close();

            return workerId;
        }

    }
}
