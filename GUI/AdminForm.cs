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
    public partial class AdminForm : Form
    {
        private BindingSource itemList = new BindingSource();
        private BindingSource brandList = new BindingSource();
        private BindingSource customerList = new BindingSource();
        private BindingSource userList = new BindingSource();

        int userId;
        public AdminForm(int userId)
        {
            InitializeComponent();

            this.userId = userId;

            dgvItem.DataSource = itemList;
            fillDgvItem("");
            addItemBinding();

            dgvBrand.DataSource = brandList;
            fillDgvBrand("");
            addBrandBinding();

            dgvCustomer.DataSource = customerList;
            fillDgvCustomer("");
            addCustomerBinding();

            dgvUser.DataSource = userList;
            fillDgvUser("");
            addUserBinding();

            prepareForUser();

        }

        void prepareForUser()
        {
            User user = UserBLL.getInstance().getUserById(userId);
            if(!user.IsAdmin)
            {
/*                btnItemAdd.Enabled = false;
                btnItemEdit.Enabled = false;
                btnItemDel.Enabled = false;
                btnCustomerDel.Enabled = false;
                btnUserAdd.Enabled = false;
                btnUserEdit.Enabled = false;
                btnUserDel.Enabled = false;
                btnBrandAdd.Enabled = false;
                btnBrandEdit.Enabled = false;
                btnBrandDelete.Enabled= false;
                btnUserResetPassword.Enabled = false;*/
                btnCustomerDel.Visible = false;

                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage5);

                nudCustomerPoint.Enabled = false;


            }
        }
        private void fillDgvItem(string nameContains)
        {
            ItemBLL.getInstance().fillDgvItem(itemList, nameContains);
            CategoryBLL.getInstance().fillCbxCategory(cbItemCategory);
        }
        private void addItemBinding()
        {
            tbItemId.DataBindings.Add(new Binding("Text", dgvItem.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbItemName.DataBindings.Add(new Binding("Text", dgvItem.DataSource, "name", true, DataSourceUpdateMode.Never));
            nudItemPrice.DataBindings.Add(new Binding("Value", dgvItem.DataSource, "price", true, DataSourceUpdateMode.Never));
            nudItemDiscount.DataBindings.Add(new Binding("Value", dgvItem.DataSource, "discount", true, DataSourceUpdateMode.Never));
            nudItemQuantity.DataBindings.Add(new Binding("Value", dgvItem.DataSource, "quantity", true, DataSourceUpdateMode.Never));
            nudSold.DataBindings.Add(new Binding("Value", dgvItem.DataSource, "sold", true, DataSourceUpdateMode.Never));
            cbItemBrand.DataBindings.Add(new Binding("SelectedValue", dgvItem.DataSource, "brand_id", true, DataSourceUpdateMode.Never));
            cbItemBrand.DataBindings.Add(new Binding("DataSource", dgvBrand, "DataSource", true, DataSourceUpdateMode.Never));
            cbItemBrand.DisplayMember= "name";
            cbItemBrand.ValueMember= "id";
            cbItemCategory.DataBindings.Add(new Binding("SelectedValue", dgvItem.DataSource, "category_id", true, DataSourceUpdateMode.Never));
        }

        private void fillDgvBrand(string nameContains)
        {
            BrandBLL.getInstance().fillDgvBrand(brandList, nameContains);
        }

        private void addBrandBinding()
        {
            tbBrandId.DataBindings.Add(new Binding("Text", dgvBrand.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbBrandName.DataBindings.Add(new Binding("Text", dgvBrand.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        private void fillDgvCustomer(string nameContains)
        {
            CustomerBLL.getInstance().fillDgvCustomer(customerList, nameContains);
        }

        private void addCustomerBinding() 
        {
            tbCustomerId.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbCustomerName.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "name", true, DataSourceUpdateMode.Never));
            tbCustomerPhoneNumber.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "phoneNumber", true, DataSourceUpdateMode.Never));
            nudCustomerPoint.DataBindings.Add(new Binding("Value", dgvCustomer.DataSource, "point"));
        }

        private void fillDgvUser(string nameContains)
        {
            UserBLL.getInstance().fillDgvUser(userList, nameContains, userId);
        }

        private void addUserBinding()
        {
            tbUserId.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbUserUsername.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "username", true, DataSourceUpdateMode.Never));
            tbUserName.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "name", true, DataSourceUpdateMode.Never));
            tbUserPhoneNumber.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "phoneNumber", true, DataSourceUpdateMode.Never));
            cbUserPosition.DataSource = new List<Position> { new Position(true, "Admin"), new Position(false, "Nhân viên") };
            cbUserPosition.ValueMember = "isAdmin";
            cbUserPosition.DisplayMember = "name";
            cbUserPosition.DataBindings.Add(new Binding("SelectedValue", dgvUser.DataSource, "isAdmin", true, DataSourceUpdateMode.Never));
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item(-1, tbItemName.Text, (int)cbItemBrand.SelectedValue, (int)cbItemCategory.SelectedValue, (int)nudItemPrice.Value, (int)nudItemDiscount.Value, (int)nudItemQuantity.Value, (int)nudSold.Value);
                if (new LaptopForm(item, LaptopForm.Mode.ADDING).ShowDialog() == DialogResult.OK)
                {
                    fillDgvItem(tbItemSearch.Text);
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void btnItemEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item(Convert.ToInt32(tbItemId.Text), tbItemName.Text, (int)cbItemBrand.SelectedValue, (int)cbItemCategory.SelectedValue, (int)nudItemPrice.Value, (int)nudItemDiscount.Value, (int)nudItemQuantity.Value, (int)nudSold.Value);
                if (new LaptopForm(item, LaptopForm.Mode.EDITING).ShowDialog() == DialogResult.OK)
                {
                    fillDgvItem(tbItemSearch.Text);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnItemShow_Click(object sender, EventArgs e)
        {
            try
            {

                Item item = new Item();
                item.Id = Convert.ToInt32(tbItemId.Text);
                new LaptopForm(item, LaptopForm.Mode.SHOWING).ShowDialog();
            }
            catch { return; }
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemBLL.getInstance().deleteLaptop(Convert.ToInt32(tbItemId.Text)))
                {
                    MessageBox.Show("Xóa thành công");
                    fillDgvItem(tbItemSearch.Text);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            catch { return; }
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            fillDgvItem(tbItemSearch.Text);

        }

        private void btnBrandAdd_Click(object sender, EventArgs e)
        {
            if(BrandBLL.getInstance().addBrand(tbBrandName.Text))
            {
                MessageBox.Show("Thêm thành công");
                fillDgvBrand(tbBrandSearch.Text);
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnBrandEdit_Click(object sender, EventArgs e)
        {
            if (BrandBLL.getInstance().updateBrand(new Brand(Convert.ToInt32(tbBrandId.Text), tbBrandName.Text)))
            {
                MessageBox.Show("Sửa thành công");
                fillDgvBrand(tbBrandSearch.Text);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnBrandDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại");
            }

            if (BrandBLL.getInstance().deleteBrand(Convert.ToInt32(tbBrandId.Text)))
            {
                MessageBox.Show("Xóa thành công");
                fillDgvBrand(tbBrandSearch.Text);
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnBrandSearch_Click(object sender, EventArgs e)
        {
            fillDgvBrand(tbBrandSearch.Text);
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(-1, tbCustomerName.Text, tbCustomerPhoneNumber.Text, (int)nudCustomerPoint.Value);
            if(CustomerBLL.getInstance().addCustomer(customer))
            {
                MessageBox.Show("Thêm thành công");
                fillDgvCustomer(tbCustomerSearch.Text);
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnCustomerEdit_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(Convert.ToInt32(tbCustomerId.Text), tbCustomerName.Text, tbCustomerPhoneNumber.Text, (int)nudCustomerPoint.Value);
            if (CustomerBLL.getInstance().updateCustomer(customer))
            {
                MessageBox.Show("Sửa thành công");
                fillDgvCustomer(tbCustomerSearch.Text);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnCustomerDel_Click(object sender, EventArgs e)
        {
            if (CustomerBLL.getInstance().deleteCustomer(Convert.ToInt32(tbCustomerId.Text)))
            {
                MessageBox.Show("Xóa thành công");
                fillDgvCustomer(tbCustomerSearch.Text);
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            fillDgvCustomer(tbCustomerSearch.Text);
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            if(UserBLL.getInstance().addUser(tbUserUsername.Text, tbUserName.Text, tbUserPhoneNumber.Text, (bool)cbUserPosition.SelectedValue))
            {
                MessageBox.Show("Thêm thành công");
                fillDgvUser(tbUserSearch.Text);

            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnUserEdit_Click(object sender, EventArgs e)
        {
            if (UserBLL.getInstance().updateUser(tbUserId.Text, tbUserName.Text, tbUserPhoneNumber.Text, (bool)cbUserPosition.SelectedValue))
            {
                MessageBox.Show("Sửa thành công");
                fillDgvUser(tbUserSearch.Text);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnUserDel_Click(object sender, EventArgs e)
        {
            if (UserBLL.getInstance().deleteUser(tbUserId.Text))
            {
                MessageBox.Show("Xóa thành công");
                fillDgvUser(tbUserSearch.Text);
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnUserSearch_Click(object sender, EventArgs e)
        {
            fillDgvUser(tbUserSearch.Text);
        }

        private void btnUserResetPassword_Click(object sender, EventArgs e)
        {
            if(UserBLL.getInstance().resetPassword(tbUserId.Text))
            {
                MessageBox.Show("Đặt lại MK thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại MK thất bại");
            }
        }
    }


}
