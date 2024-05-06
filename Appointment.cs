using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Appointment
    {
        private string appointmentId;
        private DateTime dateTime;
        private string content;
        private string status ;
        private string workerName;
        private string workerImagePath;
        private string userImagePath;
        private string userName;
        
        public Appointment(  DateTime dateTime, string content, string workerName = null, string workerImagePath = null, string userImagePath = null, string userName = null, string appointmentId = null)
        {
            this.appointmentId = appointmentId;
            this.dateTime = dateTime;
            this.content = content;
            this.userImagePath = userImagePath;
            this.userName = userName;
            this.workerName = workerName;
            this.workerImagePath = workerImagePath;
        }

        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Content { get => content; set => content = value; }
        public string Status { get => status; set => status = value; }
        public string WorkerName { get => workerName; set => workerName = value; }
        public string WorkerImagePath { get => workerImagePath; set => workerImagePath = value; }
        public string UserImagePath { get => userImagePath; set => userImagePath = value; }
        public string UserName { get => userName; set => userName = value; }
        public string AppointmentId { get => appointmentId ; set => appointmentId = value; }

    }
}
