using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderSimple
    {
        private int id;
        private string customer;
        private String order_status;
        private String date_order;
        private String date_complete;
        private int total_price;


        public OrderSimple() { }
        public OrderSimple(SqlDataReader row)
        {
            Id = row.GetInt32(0);
            Customer = row.GetString(1);

            int status = row.GetInt32(2);
            Order_status = status == 0 ? "Chuẩn bị" : status == 1 ? "Hoàn thành" : "Hủy";
            Date_order = row.GetDateTime(3).ToString("d");
            try
            {
                Date_complete = row.GetDateTime(4).ToString("d");
            }
            catch { date_complete = "-/-/-"; }
            Total_price = row.GetInt32(5);
        }

        public int Id { get => id; set => id = value; }
        public string Customer { get => customer; set => customer = value; }
        public string Order_status { get => order_status; set => order_status = value; }
        public String Date_order { get => date_order; set => date_order = value; }
        public String Date_complete { get => date_complete; set => date_complete = value; }
        public int Total_price { get => total_price; set => total_price = value; }
    }
}
