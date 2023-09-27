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
    public partial class ChangePasswordForm : Form
    {
        int userId;
        public ChangePasswordForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(UserBLL.getInstance().changePassword(userId, tbOldPassword.Text, tbNewPassword.Text, tbReNewPassword.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
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
