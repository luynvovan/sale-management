using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Brand
    {
        private int id;
        private string name;

        public Brand(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Brand(SqlDataReader row)
        {
            id = row.GetInt32(0);
            name = row.GetString(1);
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
