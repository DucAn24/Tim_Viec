using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
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


    }
}
