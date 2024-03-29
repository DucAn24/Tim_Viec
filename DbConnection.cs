using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;

namespace TimViec
{
    public class DbConnection
    {
        private string connectionString;
        private SqlConnection connection;

        public DbConnection()
        {
            // Assign the connection string directly
            connectionString = @"Data Source=DucAn\SQLEXPRESS;Initial Catalog=TimViec;Integrated Security=True;Trust Server Certificate=True";
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

        public DataTable ExecuteQuery(SqlCommand command)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // Assign the connection to the command
                command.Connection = this.Connection;

                // Create a SqlDataAdapter and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
            return dataTable;
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    // Display a success message box
                    MessageBox.Show("Command executed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return result;
                }
                catch (Exception ex)
                {
                    // Display an error message box
                    MessageBox.Show($"Error executing command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }


        public SqlConnection Connection
        {
            get { return connection; }
        }




    }
}
