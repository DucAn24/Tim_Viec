using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Client : Person
    {
        public Client(string name, string email, DateTime dateOfBirth, string profilePicture, string phone, string address, string gender) : base(name, email, dateOfBirth, profilePicture, phone, address, gender)
        {
        }
    }
}
