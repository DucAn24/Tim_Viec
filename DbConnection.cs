using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TimViec
{
    public class DbConnection
    {
        private string connectionString;
        private SqlConnection connection;

        public DbConnection(string server, string database, string username, string password)
        {
            // Create the connection string
            connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            try
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Connection opened successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
            }
        }

        public void Close()
        {
            try
            {
                // Close the connection
                connection.Close();
                Console.WriteLine("Connection closed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing connection: {ex.Message}");
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Create a SqlCommand object and execute the query
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
            return dataTable;
        }
    }
}
