using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class UserDAO
    {
        DbConnection conn = new DbConnection();

        public void AddInformation(User user)
        {
            string sql = string.Format("INSERT INTO Person(FirstName, LastName, Email, DateOfBirth, ProfilePicture, Phone, Address, Gender) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", user.FirstName, user.LastName, user.Email, user.DateOfBirth, user.ProfilePicture, user.Phone, user.Address, user.Gender);
            conn.Execute(sql);
        }
    }
}

