using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class AccountDAO
    {
        DbConnection connection = new DbConnection();

        public bool RegisterUser(string username, string password, bool isClient)
        {
            bool success = false;

            // Open the connection
            connection.Open();

            // Create a SQL command to insert a new user
            using (SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", connection.Connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Consider hashing this!
                command.Parameters.AddWithValue("@Role", isClient ? 0 : 1); // Assuming 0 is Client and 1 is Worker

                // Execute the command
                int result = connection.ExecuteNonQuery(command);

                // If the result is 1, the user was inserted successfully
                if (result == 1)
                {
                    success = true;
                }
            }
            connection.Close();

            return success;
        }
        public (int UserId, int Role) GetUserIdAndRole(string username, string password)
        {
            // Open the connection
            connection.Open();

            // Create a SQL command to get the role based on the username and password
            using (SqlCommand command = new SqlCommand("SELECT user_id, Role FROM Users WHERE Username = @Username AND Password = @Password", connection.Connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Consider hashing this!

                // Execute the command
                SqlDataReader reader = command.ExecuteReader();

                // If the result contains rows, return the user id and role
                if (reader.Read())
                {
                    return (Convert.ToInt32(reader["user_id"]), Convert.ToInt32(reader["Role"]));
                }
                else
                {
                    // If the result does not contain any rows, return -1 to indicate an error
                    return (-1, -1);
                }
            }
        }




    }
}
