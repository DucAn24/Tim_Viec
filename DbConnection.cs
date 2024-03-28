using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TimViec
{
    public class DbConnection
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr);

        public SqlConnection GetSqlConnection() 
        {
            return connection;
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

        public void Execute(string strSql)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(strSql, connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Succes");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Failed" + exc);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
