using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class UserInforForm : Form
    {
        int id;
        public UserInforForm(int id)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.id = id;
            User user = UserBLL.getInstance().getUserById(id);
            tbId.Text = user.Id.ToString();
            tbUsername.Text = user.Username;
            tbName.Text = user.Name;
            tbPhoneNumber.Text = user.PhoneNumber;
            tbPosition.Text = user.IsAdmin ? "Admin" : "Nhân viên";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (UserBLL.getInstance().updateUserInfor(id, tbName.Text, tbPhoneNumber.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                this.DialogResult= DialogResult.OK;
                this.Dispose();
            }
            else
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
