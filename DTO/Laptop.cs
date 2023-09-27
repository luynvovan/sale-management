using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Laptop
    {
        private int id;
        private float screen_size;
        private string cpu_name;
        private int ram_size;
        private int ssd_size;
        private int hdd_size;
        private float weigh;

        public Laptop() { }
        public Laptop(SqlDataReader row)
        {
            id = row.GetInt32(0);
            screen_size = (float)row.GetDouble(1);
            cpu_name = row.GetString(2);
            ram_size = row.GetInt32(3);
            ssd_size = row.GetInt32(4);
            hdd_size = row.GetInt32(5);
            weigh = (float)row.GetDouble(6);
        }

        public string toInsertString()
        {
            return screen_size + ", '" + cpu_name + "', " + ram_size + ", " + ssd_size + ", " + hdd_size + ", " + weigh;
        }

        public Laptop(int id, float screen_size, string cpu_name, int ram_size, int ssd_size, int hdd_size, float weigh)
        {
            this.id = id;
            this.screen_size = screen_size;
            this.cpu_name = cpu_name;
            this.ram_size = ram_size;
            this.ssd_size = ssd_size;
            this.hdd_size = hdd_size;
            this.weigh = weigh;
        }

        public int Id { get => id; set => id = value; }
        public float Screen_size { get => screen_size; set => screen_size = value; }
        public string Cpu_name { get => cpu_name; set => cpu_name = value; }
        public int Ram_size { get => ram_size; set => ram_size = value; }
        public int Ssd_size { get => ssd_size; set => ssd_size = value; }
        public int Hdd_size { get => hdd_size; set => hdd_size = value; }
        public float Weigh { get => weigh; set => weigh = value; }
    }
}
