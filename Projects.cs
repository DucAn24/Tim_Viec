﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Projects : Person
    {
        private String title;
        private String description;
        private String minBudge;
        private String maxBudge;
        private String category;

        public Projects(string firstName, string lastName, string email, DateTime dateOfBirth, string profilePicture, string phone, string address, string gender, string title, string description, string minBudge, string maxBudge, string category) : base(firstName, lastName, email, dateOfBirth, profilePicture, phone, address, gender)
        {
            this.title = title;
            this.description = description;
            this.minBudge = minBudge;
            this.maxBudge = maxBudge;
            this.category = category;
        }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string MinBudge { get => minBudge; set => minBudge = value; }
        public string MaxBudge { get => maxBudge; set => maxBudge = value; }
        public string Category { get => category; set => category = value; }
    }
}