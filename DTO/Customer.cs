using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        int id;
        string name;
        string phoneNumber;
        int point;

        public Customer() { }

        public Customer(SqlDataReader row)
        {
            id = row.GetInt32(0);
            name = row.GetString(1);
            phoneNumber = row.GetString(2);
            point = row.GetInt32(3);
        }
        public Customer(int id, string name, string phoneNumber, int point)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.point = point;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Point { get => point; set => point = value; }
    }
}
