﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class User : Person
    {
        public User(string firstName, string lastName, string email, DateTime dateOfBirth, string profilePicture, string phone, string address, string gender) : base(firstName, lastName, email, dateOfBirth, profilePicture, phone, address, gender)
        {
        }
    }
}
