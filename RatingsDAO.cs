using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class RatingsDAO
    {
        DbConnection connection = new DbConnection();

        public bool AddRatings(Ratings ratings, int workerId, int userId)
        {
            string sqlStr = "INSERT INTO Ratings (Worker_id, user_id, Stars, Comment) VALUES(@WorkerId, @UserId, @Stars, @Comment)";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("Stars", ratings.Stars);
                command.Parameters.AddWithValue("@Comment", ratings.Comment);
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();
                return rowsAffected > 0;
            }
        }

        public bool UpdateRatings(Ratings ratings, int workerId, int userId)
        {
            string sqlStr = "UPDATE Ratings SET Stars = @Stars, Comment = @Comment WHERE Worker_id = @WorkerId AND user_id = @UserId";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("Stars", ratings.Stars);
                command.Parameters.AddWithValue("@Comment", ratings.Comment);
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();
                return rowsAffected > 0;
            }
        }

        public bool RatingExists(int workerId, int userId)
        {
            string sqlStr = "SELECT COUNT(*) FROM Ratings WHERE Worker_id = @WorkerId AND user_id = @UserId";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                connection.Close();
                return count > 0;
            }
        }




    }
}
