using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class UserBLL
    {
        private UserBLL() { }

        private static UserBLL instance = null;

        public static UserBLL getInstance()
        {
            if(instance == null)
            {
                instance = new UserBLL();
            }
            return instance;
        }
        public int login(string username, string password)
        {
            return UserAccess.getInstance().login(username, password);
        }

        public bool updateUserInfor(int id, string name, string phoneNumber)
        {
            try { return UserAccess.getInstance().updateUserInfor(new User(id, "", name, phoneNumber, false)); }
            catch(Exception e) { return false; }
        }

        public bool changePassword(int id, string oldPassword, string newPassword, string reNewPassword)
        {
            if(newPassword != reNewPassword)
                return false;
            return UserAccess.getInstance().changePassword(id, oldPassword, newPassword);
        }

        public bool addUser(string username, string name, string phoneNumber, bool isAdmin)
        {
            try
            {
                return UserAccess.getInstance().addUser(new User(-1, username, name, phoneNumber, isAdmin));
            }
            catch (Exception e) { return false; }
        }

        public void fillDgvUser(BindingSource userList, string nameContains, int exceptId)
        {
            userList.DataSource = UserAccess.getInstance().getUserList(nameContains, exceptId);
        }

        public bool deleteUser(string id)
        {
            try
            {
                return UserAccess.getInstance().deleteUser(Convert.ToInt32(id));
            }
            catch(Exception e) { return false; }
        }

        public bool updateUser(string id, string name, string phoneNumber, bool isAdmin)
        {
            try
            {
                return UserAccess.getInstance().updateUser(new User(Convert.ToInt32(id), "", name, phoneNumber, isAdmin));
            }
            catch (Exception e) { return false; }
        }

        public User getUserById(int id)
        {
            return UserAccess.getInstance().getUserById(id);
        }

        public bool resetPassword(string id)
        {
            try { return UserAccess.getInstance().resetPassword(Convert.ToInt32(id)); } catch (Exception e) { return false; }
        }
    }
}
