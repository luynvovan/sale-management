using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        

        private int id;
        private string username;
        private string name;
        private string phoneNumber;
        private bool isAdmin;

        public User(SqlDataReader row)
        {
            id = row.GetInt32(0);
            username = row.GetString(1);
            name = row.GetString(2);
            phoneNumber = row.GetString(3);
            isAdmin = row.GetBoolean(4);
        }
        public User(int id, string username, string name, string phoneNumber, bool isAdmin)
        {
            this.id = id;
            this.username = username;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.isAdmin = isAdmin;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
