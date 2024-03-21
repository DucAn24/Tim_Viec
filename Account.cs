using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class Account
    {
        private String username;
        private String password;

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }

        public string Password { get => password; set => password = value; }
    }
}
