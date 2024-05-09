using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class ClientDAO
    {
        DbConnection connection = new DbConnection();
        public bool UpdateInformation(Client client, int userId)
        {
            string sqlStr = "UPDATE Users SET Name = @Name, Email = @Email, DateOfBirth = @DateOfBirth, ImagePath = @ImagePath, PhoneNumber = @Phone, Address = @Address, Gender = @Gender WHERE user_id = @UserId";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@Name", client.Name);
                command.Parameters.AddWithValue("@Email", client.Email);
                command.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ImagePath", client.ImagePath);
                command.Parameters.AddWithValue("@Phone", client.Phone);
                command.Parameters.AddWithValue("@Address", client.Address);
                command.Parameters.AddWithValue("@Gender", client.Gender);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rowsAffected = connection.ExecuteNonQuery(command);
                connection.Close();

                return rowsAffected > 0;
            }
        }

        public Client LoadUserData(int userId)
        {
            Client client = null;

            string selectQuery = @"
                    SELECT Name, Email, Address, PhoneNumber, Gender, DateOfBirth, ImagePath
                    FROM Users
                    WHERE user_id = @UserId
                ";

            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection.Connection))
            {
                selectCommand.Parameters.AddWithValue("@UserId", userId);
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

                    client = new Client(name, email, dateOfBirth, imagePath, phoneNumber, address, gender);
                }

                connection.Close();
            }

            return client;
        }

        public bool HireWorker(int userId, int workerId)
        {
            bool success = false;

            connection.Open();

            string checkQuery = @"
                SELECT COUNT(*)
                FROM HiredWorkers
                WHERE user_id = @UserId AND Worker_id = @WorkerId
            ";

            SqlCommand checkCommand = new SqlCommand(checkQuery, connection.Connection);
            checkCommand.Parameters.AddWithValue("@UserId", userId);
            checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

            int count = (int)checkCommand.ExecuteScalar();

            if (count > 0)
            {
                success = false;
            }
            else
            {
                string insertQuery = @"
                    INSERT INTO HiredWorkers (user_id, Worker_id)
                    VALUES (@UserId, @WorkerId)
                ";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection.Connection);

                insertCommand.Parameters.AddWithValue("@UserId", userId);
                insertCommand.Parameters.AddWithValue("@WorkerId", workerId);

                try
                {
                    insertCommand.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {

                }
            }

            connection.Close();

            return success;
        }

        public bool AddWorkerToFavourites(int userId, int workerId)
        {
            bool success = false;

            connection.Open();

            string checkQuery = @"
                    SELECT isFavourite
                    FROM Favourite
                    WHERE user_id = @UserId AND Worker_id = @WorkerId
                ";

            SqlCommand checkCommand = new SqlCommand(checkQuery, connection.Connection);
            checkCommand.Parameters.AddWithValue("@UserId", userId);
            checkCommand.Parameters.AddWithValue("@WorkerId", workerId);

            object result = checkCommand.ExecuteScalar();

            if (result != null && result.ToString() == "false")
            {
                string updateQuery = @"
                                    UPDATE Favourite
                                    SET isFavourite = 'true'
                                    WHERE user_id = @UserId AND Worker_id = @WorkerId
                                ";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection.Connection);
                updateCommand.Parameters.AddWithValue("@UserId", userId);
                updateCommand.Parameters.AddWithValue("@WorkerId", workerId);

                try
                {
                    updateCommand.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {

                }
            }
            else if (result == null)
            {
                string insertQuery = @"
                            INSERT INTO Favourite (user_id, Worker_id, isFavourite)
                            VALUES (@UserId, @WorkerId, 'true')
                        ";

                SqlCommand insertCommand = new SqlCommand(insertQuery, connection.Connection);
                insertCommand.Parameters.AddWithValue("@UserId", userId);
                insertCommand.Parameters.AddWithValue("@WorkerId", workerId);

                try
                {
                    insertCommand.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {

                }
            }

            connection.Close();

            return success;
        }

        public bool RemoveWorkerToFavourites(int userId, int workerId)
        {
            bool success = false;
            connection.Open();

            string query = @"
                        UPDATE Favourite
                        SET isFavourite = 'false'
                        WHERE user_id = @UserId AND Worker_id = @WorkerId
                    ";

            SqlCommand updateCommand = new SqlCommand(query, connection.Connection);
            updateCommand.Parameters.AddWithValue("@UserId", userId);
            updateCommand.Parameters.AddWithValue("@WorkerId", workerId);

            try
            {
                updateCommand.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {

            }

            connection.Close();

            return success;
        }


        public DataTable LoadDataHired(int userId)
        {
            string query = @"
                            SELECT W.Category,
                                    U.Name,
                                    U.ImagePath,
                                    U.Email,
                                    U.PhoneNumber
                            FROM Worker W
                            JOIN HiredWorkers H
                                ON W.Worker_id = H.Worker_id
                            JOIN Users U
                                ON U.user_id = W.user_id
                            WHERE H.user_id = @UserId
                        ";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();
            DataTable dataTable = connection.ExecuteQuery(command);
            connection.Close();

            return dataTable;
        }

        public DataTable LoadDataFavourite(int userId)
        {
            string query = @"
                            SELECT W.Category,
                                    U.Name,
                                    U.ImagePath,
                                    U.PhoneNumber,
                                    U.Email,
                                    U.DateOfBirth,
                                    U.Address,
                                    W.Worker_id                                    
                            FROM Worker W
                            JOIN Favourite F
                                ON W.Worker_id = F.Worker_id
                            JOIN Users U
                                ON U.user_id = W.user_id                     
                            WHERE F.user_id = @UserId AND F.isFavourite = 'true'
                        ";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();
            DataTable dataTable = connection.ExecuteQuery(command);
            connection.Close();

            return dataTable;
        }


    }
}
