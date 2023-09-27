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
    public partial class LaptopForm : Form
    {
        public enum Mode
        {
            EDITING, ADDING, SHOWING
        }

        private Laptop laptop;
        private Item item;
        public LaptopForm(Item item, Mode mode)
        {
            InitializeComponent();
            this.item = item;
            if (mode == Mode.SHOWING || mode == Mode.EDITING)
            {
                laptop = ItemBLL.getInstance().getLaptop(item.Id);
                tbId.Text = laptop.Id.ToString();
                tbScreen.Text = laptop.Screen_size.ToString();
                tbCpu.Text = laptop.Cpu_name;
                nudRam.Value = laptop.Ram_size;
                nudSsd.Value = laptop.Ssd_size;
                nudHdd.Value = laptop.Hdd_size;
                tbWeight.Text = laptop.Weigh.ToString();
                if(mode == Mode.EDITING)
                {
                    btnComfirm.Click += btnComfirmClickedEditing;
                }
                else
                {
                    btnComfirm.Click += btnComfirmClickedShowing;
                    btnExit.Visible = false;
                }
            }
            else
            {
                laptop = new Laptop();
                btnComfirm.Click += btnComfirmClickedAdding;
            }
        }

        private void btnComfirmClickedEditing(object sender, EventArgs e)
        {
            try
            {
                laptop.Screen_size = (float)Convert.ToDouble(tbScreen.Text);
                laptop.Cpu_name = tbCpu.Text;
                laptop.Ram_size = (int)nudRam.Value;
                laptop.Ssd_size = (int)nudSsd.Value;
                laptop.Hdd_size = (int)nudHdd.Value;
                laptop.Weigh = (float)Convert.ToDouble(tbWeight.Text);
            }
            catch { return; }

            if (ItemBLL.getInstance().updateLaptop(item, laptop))
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnComfirmClickedAdding(object sender, EventArgs e)
        {
            try
            {
                laptop.Screen_size = (float)Convert.ToDouble(tbScreen.Text);
                laptop.Cpu_name = tbCpu.Text;
                laptop.Ram_size = (int)nudRam.Value;
                laptop.Ssd_size = (int)nudSsd.Value;
                laptop.Hdd_size = (int)nudHdd.Value;
                laptop.Weigh = (float)Convert.ToDouble(tbWeight.Text);
            }
            catch { return; }

            if (ItemBLL.getInstance().addLaptop(item, laptop))
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnComfirmClickedShowing(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
