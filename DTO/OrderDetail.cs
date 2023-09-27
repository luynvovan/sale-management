using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetail
    {
        private int item_id;
        private string item_name;
        private string brand;
        private int price;
        private int discount;
        private int quantity;
        private int total_price;

        public OrderDetail(SqlDataReader row) 
        {
            item_id = row.GetInt32(0);
            item_name = row.GetString(1);
            brand = row.GetString(2);
            price = row.GetInt32(3);
            discount = row.GetInt32(4);
            quantity = row.GetInt32(5);
            int priceDiscount = (int)((float)price * (float)discount / 100f);
            total_price = (price - priceDiscount) * quantity;
        }
        public OrderDetail() { }

        public OrderDetail(int item_id, string item_name, string brand, int price, int discount, int quantity, int total_price)
        {
            this.Item_id = item_id;
            this.Item_name = item_name;
            this.Brand = brand;
            this.Price = price;
            this.Discount = discount;
            this.Quantity = quantity;
            this.Total_price = total_price;
        }

        public int Item_id { get => item_id; set => item_id = value; }
        public string Item_name { get => item_name; set => item_name = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Total_price { get => total_price; set => total_price = value; }
    }
}
