using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Worker : Person
    {
        private string bio;
        private string skills;
        private string category;
        private string salary;

        public Worker(string name, string email, DateTime dateOfBirth, string imagePath, string phone, string address, string gender, string bio, string skills, string category, string salary)
            : base(name, email, dateOfBirth, imagePath, phone, address, gender)
        {
            this.bio = bio;
            this.skills = skills;
            this.category = category;
            this.salary = salary;
        }

        public string Bio { get => bio; set => bio = value; }
        public string Skills { get => skills; set => skills = value; }
        public string Category { get => category; set => category = value; }

        public string Salary { get => salary; set => salary = value; }
    }
}
