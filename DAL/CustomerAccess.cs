using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerAccess
    {
        private CustomerAccess() { }

        private static CustomerAccess instance = null;

        public static CustomerAccess getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerAccess();
            }
            return instance;
        }

        public List<Customer> getCustomerList(string nameContains)
        {
            List<Customer> list = new List<Customer>();

            string queryString;
            if (nameContains == "")
                queryString = "SELECT * FROM customer";
            else
                queryString = "SELECT * FROM customer WHERE name LIKE N'%" + nameContains + "%'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Customer(reader));
                        }
                    }
                }
            }
            return list;
        }
        public bool addCustomer(Customer customer)
        {
            string queryString = "INSERT INTO customer (name, phoneNumber, point) VALUES (N'" + customer.Name + "', '" + customer.PhoneNumber + "', " + customer.Point +")";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    {
                        return command.ExecuteNonQuery() == 1;
                    }
                }
            }
        }
        public bool deleteCustomer(int id)
        {
            string queryString = "DELETE FROM customer WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    {
                        return command.ExecuteNonQuery() == 1;
                    }
                }
            }
        }
        public bool updateCustomer(Customer customer)
        {
            string queryString = "UPDATE customer SET name = N'" + customer.Name + "', phoneNumber = '" + customer.PhoneNumber + "', point = " + customer.Point + " WHERE id = " + customer.Id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    {
                        return command.ExecuteNonQuery() == 1;
                    }
                }
            }
        }
        public Customer getCustomer(int id)
        {
            string queryString = "SELECT * FROM customer WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    {
                        using(SqlDataReader reader= command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Customer(reader);
                            return null;
                        }
                    }
                }
            }
        }
    }
}
