using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        private int id;
        private int customer_id;
        private int user_id;
        private string address;
        private int order_status;
        private string date_order;
        private string date_complete;
        private int discount;
        private int point_use;
        private int point_add;
        private int total_price;


        public Order() { }
        public Order(SqlDataReader row)
        {
            id = row.GetInt32(0);
            customer_id = row.GetInt32(1);
            user_id = row.GetInt32(2);
            address = row.GetString(3);
            order_status = row.GetInt32(4);
            date_order = row.GetDateTime(5).ToString("d");
            try
            {
                date_complete = row.GetDateTime(6).ToString("d");
            }
            catch { date_complete = "-/-/-"; }
            discount = row.GetInt32(7);
            point_use = row.GetInt32(8);
            point_add = row.GetInt32(9);
            total_price = row.GetInt32(10);
        }

        public Order(int customer_id, int user_id, string address, int discount, int point_use, int point_add, int total_price)
        {
            this.customer_id = customer_id;
            this.user_id = user_id;
            this.address = address;
            this.discount = discount;
            this.point_use = point_use;
            this.point_add = point_add;
            this.total_price = total_price;
        }

        public Order(int id, int customer_id, int user_id, string address, int order_status, string date_order, string date_complete, int discount, int point_use, int point_add, int total_price)
        {
            this.id = id;
            this.customer_id = customer_id;
            this.user_id = user_id;
            this.address = address;
            this.order_status = order_status;
            this.date_order = date_order;
            this.date_complete = date_complete;
            this.discount = discount;
            this.point_use = point_use;
            this.point_add = point_add;
            this.total_price = total_price;
        }


        public int Id { get => id; set => id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Address { get => address; set => address = value; }
        public int Order_status { get => order_status; set => order_status = value; }
        public string Date_order { get => date_order; set => date_order = value; }
        public string Date_complete { get => date_complete; set => date_complete = value; }
        public int Discount { get => discount; set => discount = value; }
        public int Point_use { get => point_use; set => point_use = value; }
        public int Point_add { get => point_add; set => point_add = value; }
        public int Total_price { get => total_price; set => total_price = value; }
    }
}
