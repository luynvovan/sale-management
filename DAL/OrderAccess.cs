using DTO;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderAccess
    {
        private OrderAccess() { }

        private static OrderAccess instance = null;

        public static OrderAccess getInstance()
        {
            if (instance == null)
            {
                instance = new OrderAccess();
            }
            return instance;
        }
        public int addOrder(Order order)
        {
            string queryString = "INSERT INTO sales_order (customer_id, user_id, derivery_address, discount, point_use, point_add, total_price) VALUES(" + order.Customer_id + ", " + order.User_id + ", N'" + order.Address + "', " + order.Discount + ", " + order.Point_use + ", " + order.Point_add + ", " + order.Total_price + "); SELECT CAST(scope_identity() AS INT)";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    return (int)command.ExecuteScalar();
                }
            }
        }
        public List<OrderSimple> getOrderSimpleList(string nameContains, int status)
        {
            List<OrderSimple> list = new List<OrderSimple>();
            string queryString;
            if (nameContains == "")
            {
                if(status == -1)
                    queryString = "SELECT so.id, ct.name, so.order_status, so.date_order, so.date_complete, so.total_price FROM sales_order AS so LEFT JOIN customer AS ct ON so.customer_id = ct.id";
                else
                    queryString = "SELECT so.id, ct.name, so.order_status, so.date_order, so.date_complete, so.total_price FROM sales_order AS so LEFT JOIN customer AS ct ON so.customer_id = ct.id WHERE so.order_status = " + status;
            }
            else
            {
                if (status == -1)
                    queryString = "SELECT so.id, ct.name, so.order_status, so.date_order, so.date_complete, so.total_price FROM sales_order AS so LEFT JOIN customer AS ct ON so.customer_id = ct.id WHERE ct.Name LIKE N'%" + nameContains + "%'";
                else
                    queryString = "SELECT so.id, ct.name, so.order_status, so.date_order, so.date_complete, so.total_price FROM sales_order AS so LEFT JOIN customer AS ct ON so.customer_id = ct.id WHERE ct.Name LIKE N'%" + nameContains + "%' AND so.order_status = " + status;
            }
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read()) 
                        {
                            list.Add(new OrderSimple(reader));
                        }
                    }
                }
            }
            return list;
        }
        public Order getOrder(int id)
        {
            string queryString = "SELECT * FROM sales_order WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                            return new Order(reader);
                    }
                }
            }
            return null;
        }
        public bool addOrderDetail(List<OrderDetail> orderDetailList, int order_id)
        {
           
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                foreach (OrderDetail od in orderDetailList)
                {
                    string queryString = "INSERT INTO order_detail (order_id, item_id, price, discount, quantity) VALUES (" + order_id + ", " + od.Item_id + ", " + od.Price + ", " + od.Discount + ", " + od.Quantity + ")";
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        if(command.ExecuteNonQuery() < 1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public List<OrderDetail> getOrderDetailList(int order_id)
        {
            List<OrderDetail> list = new List<OrderDetail>(); 
            string queryString = "SELECT it.item_id, it.name, brand.name, it.price, it.discount, it.quantity FROM\r\n(SELECT od.item_id, item.name, item.brand_id, item.price, item.discount, od.quantity FROM (SELECT * FROM order_detail WHERE order_id = " + order_id + ") AS od\r\nLEFT JOIN\r\nitem\r\nON od.item_id = item.id) AS it\r\nLEFT JOIN\r\nbrand\r\nON it.brand_id = brand.id";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(new OrderDetail(reader));
                        }
                        return list;
                    }
                }
            }
        }
        public bool cancelOrder(int id)
        {
            string queryString = "UPDATE sales_order SET order_status = 2 WHERE id = " + id + " AND order_status = 0";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool completeOrder(int id)
        {
            string queryString = "UPDATE sales_order SET order_status = 1 WHERE id = " + id + " AND order_status = 0";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
