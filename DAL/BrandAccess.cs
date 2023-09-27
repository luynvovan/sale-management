using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class BrandAccess
    {
        private BrandAccess() { }

        private static BrandAccess instance = null;

        public static BrandAccess getInstance()
        {
            if(instance == null)
            {
                instance = new BrandAccess();
            }
            return instance;
        }

        public List<Brand> getBrandList(string nameContains)
        {
            List<Brand> list = new List<Brand>();

            string queryString;
            if(nameContains == "")
                queryString = "SELECT * FROM brand";
            else
                queryString = "SELECT * FROM brand WHERE name LIKE N'%" + nameContains + "%'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(new Brand(reader));
                        }
                    }
                }
            }
            return list;
        }
        public bool addBrand(string name)
        {
            string queryString = "INSERT INTO brand (name) VALUES (N'" + name + "')";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool deleteBrand(int id)
        {
            string queryString = "DELETE FROM brand WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool updateBrand(Brand brand)
        {
            string queryString = "UPDATE brand SET name = N'" + brand.Name + "' WHERE id = " + brand.Id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
    }
}
