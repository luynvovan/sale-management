using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Item
    {
        private int id;
        private string name;
        private int brand_id;
        private int category_id;
        private int price;
        private int discount;
        private int quantity;
        private int sold;

        public Item() { }
        public Item(int id, string name, int brand_id, int category_id, int price, int discount, int quantity, int sold)
        {
            this.id = id;
            this.name = name;
            this.brand_id = brand_id;
            this.category_id = category_id;
            this.price = price;
            this.discount = discount;
            this.quantity = quantity;
            this.sold = sold;
        }

        public Item(SqlDataReader row)
        {
            this.id = row.GetInt32(0);
            this.name = row.GetString(1);
            this.brand_id = row.GetInt32(2);
            this.category_id = row.GetInt32(3);
            this.price = row.GetInt32(4);
            this.discount = row.GetInt32(5);
            this.quantity = row.GetInt32(6);
            this.sold = row.GetInt32(7);
        }

        public string toInsertString()
        {
            return "N'" + name + "', " + brand_id + ", " + category_id + ", " + price + ", " + discount + ", " + quantity + ", " + sold;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Brand_id { get => brand_id; set => brand_id = value; }
        public int Category_id { get => category_id; set => category_id = value; }
        public int Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Sold { get => sold; set => sold = value; }
    }
}
