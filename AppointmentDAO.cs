using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TimViec
{
    internal class AppointmentDAO
    {
        DbConnection connection = new DbConnection();

        public bool AddAppointment(Appointment appointment, int userId, int workerId)
        {
            string sqlStr = "INSERT INTO Appointment(Worker_id, user_id, Date, Content, Status) VALUES(@WorkerId, @UserId, @Date, @Content, @Status)";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("userId", userId);
                command.Parameters.AddWithValue("WorkerId", workerId);
                command.Parameters.AddWithValue("Date", appointment.DateTime);
                command.Parameters.AddWithValue("Content", appointment.Content);
                command.Parameters.AddWithValue("Status", "Pending");

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();
                return rowsAffected > 0;
            }
        }

        public List<Appointment> AppointmentsForClient(int userId)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = @"
                    SELECT U.ImagePath AS WorkerImagePath,
		                    U.Name AS WorkerName ,
		                    A.Date,
		                    A.Content,
		                    A.Status
                    FROM Appointment A
                    JOIN Worker W ON A.Worker_id = W.Worker_id
                    JOIN Users U ON W.user_id =  U.user_id
                    WHERE A.user_id = @UserId
            ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime("Date");
                    string content = reader.GetString("Content");
                    string status = reader.GetString("Status");
                    string workerName = reader.GetString("WorkerName");
                    string workerImagePath = reader.GetString("WorkerImagePath");


                    Appointment appointment = new Appointment(date, content, workerName, workerImagePath, null, null,null);
                    appointment.Status = status;

                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }

        public List<Appointment> AppointmentsForWorker(int workerId)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = @"
                            SELECT A.appointment_id,
                                    U.ImagePath AS UserImagePath,
                                    U.Name AS UserName,
                                    A.Date,
                                    A.Content,
                                    A.Status
                            FROM Appointment A
                            JOIN Users U ON A.user_id = U.user_id
                            WHERE A.Worker_id = @WorkerId
            ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@WorkerId", workerId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int appointmentId = reader.GetInt32("appointment_id");

                    DateTime date = reader.GetDateTime("Date");
                    string content = reader.GetString("Content");
                    string status = reader.GetString("Status");
                    string userName = reader.GetString("UserName");
                    string userImagePath = reader.GetString("UserImagePath");


                    Appointment appointment = new Appointment(date, content, null, null,userImagePath, userName, null);
                    appointment.Status = status;

                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }


        public List<Appointment> SearchForClient(int userId, string statusPick)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = @"
                    SELECT U.ImagePath AS WorkerImagePath,
		                    U.Name AS WorkerName ,
		                    A.Date,
		                    A.Content,
		                    A.Status
                    FROM Appointment A
                    JOIN Worker W ON A.Worker_id = W.Worker_id
                    JOIN Users U ON W.user_id =  U.user_id
                    WHERE A.user_id = @UserId AND A.Status = @Status
            ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Status", statusPick);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime("Date");
                    string content = reader.GetString("Content");
                    string status = reader.GetString("Status");
                    string workerName = reader.GetString("WorkerName");
                    string workerImagePath = reader.GetString("WorkerImagePath");


                    Appointment appointment = new Appointment(date, content, workerName, workerImagePath, null, null,null);
                    appointment.Status = status;

                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }

        public List<Appointment> SearchForWorker(int workerId, string statusPick)
        {
            List<Appointment> appointments = new List<Appointment>();

            string query = @"
                    SELECT U.ImagePath AS UserImagePath,
                            U.Name AS UserName,
                            A.Date,
                            A.Content,
                            A.Status,
                            A.appointment_id
                    FROM Appointment A
                    JOIN Users U ON A.user_id = U.user_id
                    WHERE A.Worker_id = @WorkerId AND A.Status = @Status
            ";

            using (SqlCommand command = new SqlCommand(query, connection.Connection))
            {
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@Status", statusPick);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string appointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id")).ToString();

                    DateTime date = reader.GetDateTime("Date");
                    string content = reader.GetString("Content");
                    string status = reader.GetString("Status");
                    string UserName = reader.GetString("UserName");
                    string UserImagePath = reader.GetString("UserImagePath");


                    Appointment appointment = new Appointment(date, content, null, null, UserImagePath, UserName, appointmentId);
                    appointment.Status = status;


                    appointments.Add(appointment);
                }

                connection.Close();
            }

            return appointments;
        }

        public bool UpdateAppointmentStatus(string appointmentId, string status)
        {
            string sqlStr = "UPDATE Appointment SET Status = @Status WHERE appointment_id = @AppointmentId";

            using (SqlCommand command = new SqlCommand(sqlStr, connection.Connection))
            {
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                connection.Close();
                return rowsAffected > 0;
            }
        }



    }
}
