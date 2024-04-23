using Microsoft.Data.SqlClient;
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
    }
}
