using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryAccess
    {
        private CategoryAccess() { }

        private static CategoryAccess instance = null;

        public static CategoryAccess getInstance()
        {
            if (instance == null)
            {
                instance = new CategoryAccess();
            }
            return instance;
        }

        public List<Category> getCategoryList()
        {
            List<Category> list = new List<Category>();

            string queryString = "SELECT * FROM category";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Category(reader));
                        }
                    }
                }
            }
            return list;
        }
    }
}
