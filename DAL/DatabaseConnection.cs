using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=MIO\\INO_ERMES;Initial Catalog=sales_manegement;Integrated Security=True";

        public static string ConnectionString { get => connectionString;}
    }
}
