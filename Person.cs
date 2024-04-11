using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Person
    {
        private String name;
        private String email;
        private DateTime dateOfBirth;
        private String imagePath;
        private String phone;
        private String address;
        private String gender;

        public Person(string name, string email, DateTime dateOfBirth, string imagePath, string phone, string address, string gender)
        {
            this.name = name;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.imagePath = imagePath;
            this.phone = phone;
            this.address = address;
            this.gender = gender;
        }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
