using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserAccess
    {
        private UserAccess() { }

        private static UserAccess instance = null;

        public static UserAccess getInstance()
        {
            if(instance == null)
            {
                instance = new UserAccess();
            }
            return instance;
        }
        public int login(string username, string password)
        {
            string queryString = "SELECT id FROM app_user WHERE username = '" + username + "' AND password = '" + password + "'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                        return -1;
                    }
                }
            }
        }
        public bool updateUserInfor(User user)
        {
            string queryString = "UPDATE app_user SET name = N'" + user.Name + "', phoneNumber = '" + user.PhoneNumber + "' WHERE id = " + user.Id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool changePassword(int id, string oldPassword, string newPassword)
        {
            string queryString = "UPDATE app_user SET password = '" + newPassword + "' WHERE id = " + id + " AND password = '" + oldPassword + "'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool addUser(User user)
        {
            string queryString = "INSERT INTO app_user (username, name, phoneNumber, isAdmin) VALUES ('" + user.Username + "', N'" + user.Name + "', '" + user.PhoneNumber + "', " + (user.IsAdmin ? 1 : 0) + ")";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool deleteUser(int id)
        {
            string queryString = "DELETE FROM app_user WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool updateUser(User user) 
        {
            string queryString = "UPDATE app_user SET name = N'" + user.Name + "', phoneNumber = '" + user.PhoneNumber + "', isAdmin = " + (user.IsAdmin ? 1 : 0) + " WHERE id = " + user.Id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
        
        public List<User> getUserList(String nameContains, int exceptId)
        {
            List<User> list = new List<User>();

            string queryString;
            if (nameContains == "")
                queryString = "SELECT id, username, name, phoneNumber, isAdmin FROM app_user WHERE id <> " + exceptId;
            else
                queryString = "SELECT id, username, name, phoneNumber, isAdmin FROM app_user WHERE id <> " + exceptId + " AND name LIKE N'%" + nameContains + "%'";
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            list.Add(new User(reader));
                        }
                    }
                }
            }
            return list;
        }

        public bool resetPassword(int id)
        {
            string queryString = "EXECUTE spResetUserPassword " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
        public User getUserById(int id)
        {
            string queryString = "SELECT id, username, name, phoneNumber, isAdmin FROM app_user WHERE id = " + id;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User(reader);
                        }
                        return null;
                    }
                }
            }
        }
    }

}
