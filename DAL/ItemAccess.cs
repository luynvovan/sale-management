using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemAccess
    {
        private ItemAccess() { }

        private static ItemAccess instance = null;

        public static ItemAccess getInstance()
        {
            if(instance == null)
            {
                instance = new ItemAccess();
            }
            return instance;
        }

        public List<Item> getItemList(string nameContains)
        {
            List<Item> list = new List<Item>();

            string queryString;
            if (nameContains == "")
                queryString = "SELECT * FROM item";
            else
                queryString = "SELECT * FROM item WHERE name LIKE N'%" + nameContains + "%'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Item(reader));
                        }
                    }
                }
            }
            return list;
        }
        public Laptop getLaptop(int id)
        {
            string queryString = "SELECT * FROM laptop WHERE id = " + id;
            using(SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using(SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return new Laptop(reader);
                        }
                    }
                }
                return null;
            }
        }
        public bool addLaptop(Item item, Laptop laptop)
        {
            string queryString = "EXECUTE spInsertLaptop " + item.toInsertString() + ", " + laptop.toInsertString();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 1;
                }
            }
        }
        public bool updateLaptop(Item item, Laptop laptop)
        {
            string queryString = "EXECUTE spUpdateLaptop " + item.Id + ", " + item.toInsertString() + ", " + laptop.toInsertString();
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 1;
                }
            }

        }
        
        public bool deleteLaptop(int id)
        {
            string queryString = "DELETE FROM laptop WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public int getItemQuantity(int id)
        {
            string queryString = "SELECT quantity FROM item WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                        else
                            return 0;
                    }
                }
            }
        }
    }
}
