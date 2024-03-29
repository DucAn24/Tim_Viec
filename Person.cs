using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Person
    {
        private String firstName;
        private String lastName;
        private String email;
        private DateTime dateOfBirth;
        private String picturePath;
        private String phone;
        private String address;
        private String gender;

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth, string picturePath, string phone, string address, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.picturePath = picturePath;
            this.phone = phone;
            this.address = address;
            this.gender = gender;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
    }
}
