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
    public partial class MainForm : Form
    {

        private int userId;
        public MainForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            prepareForm();
            fillDgvOrder("", -1);
        }

        private void prepareForm()
        {
            User user = UserBLL.getInstance().getUserById(userId);
            name.Text = user.Name;
            position.Text = user.IsAdmin ? "Admin" : "Nhân viên";

            if(!user.IsAdmin)
            {
                adminToolStripMenuItem.Text = "Nhân viên";
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm(userId);
            af.ShowDialog();
        }

        private void inforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(new UserInforForm(userId).ShowDialog() == DialogResult.OK)
            {
                prepareForm();
            }
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePasswordForm(userId).ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(new MakeOrderForm(userId).ShowDialog() == DialogResult.OK)
            {
                fillDgvOrder(tbSearch.Text, cbStatus.SelectedIndex - 1);
            }
        }

        private void fillDgvOrder(string search, int status)
        {
            OrderBLL.getInstance().fillDgvSimpleOrder(dgvOrder, search, status);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillDgvOrder(tbSearch.Text, cbStatus.SelectedIndex - 1);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = ((OrderSimple)dgvOrder.SelectedRows[0].DataBoundItem).Id;
                new ShowOrder(orderId).ShowDialog();
            }
            catch { }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = ((OrderSimple)dgvOrder.SelectedRows[0].DataBoundItem).Id;
                if (OrderBLL.getInstance().completeOrder(orderId))
                {
                    fillDgvOrder(tbSearch.Text, cbStatus.SelectedIndex - 1);
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = ((OrderSimple)dgvOrder.SelectedRows[0].DataBoundItem).Id;
                if (OrderBLL.getInstance().cancelOrder(orderId))
                {
                    fillDgvOrder(tbSearch.Text, cbStatus.SelectedIndex - 1);
                }
            }
            catch { }
        }
    }
}
