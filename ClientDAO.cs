using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class ClientDAO
    {
        DbConnection connection = new DbConnection();
        public void AddInformation(Client client)
        {
            string sqlStr = string.Format("INSERT INTO Client(FirstName, LastName, Email, DateOfBirth, ImagePath, PhoneNumber, Address, Gender) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", client.FirstName, client.LastName, client.Email, client.DateOfBirth, client.ImagePath, client.Phone, client.Address, client.Gender);
            connection.Execute(sqlStr);
        }
    }
}
