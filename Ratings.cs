using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Ratings
    {
        private string comment;
        private double stars;
        private string userName;
        private string userImagePath;

        public Ratings(string comment, double stars, string userName = null, string userImagePath = null)
        {
            this.comment = comment;
            this.stars = stars;
            this.userName = userName;
            this.userImagePath = userImagePath;
        }

        public string Comment { get => comment; set => comment = value; }
        public double Stars { get => stars; set => stars = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserImagePath { get => userImagePath; set => userImagePath = value; }
    }



}
