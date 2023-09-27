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
    public partial class MakeOrderForm : Form
    {
        int userId;
        public MakeOrderForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            fillCbxItem();
            fillCbxCustomer();
            this.DialogResult = DialogResult.Cancel;
        }

        List<Brand> brandList = BrandBLL.getInstance().getBrandList();
        List<Category> categoryList = CategoryBLL.getInstance().getCategryList();
        List<OrderDetail> orderDetailList = new List<OrderDetail>();
        int order_total = 0;
        int order_lastPrice = 0;
        int usedPoint = 0;
        int point_add = 0;
        private void fillCbxItem()
        {
            cbItem.DataSource = ItemBLL.getInstance().getItemList();
            cbItem.DisplayMember = "name";
            lbItemId.DataBindings.Add(new Binding("Text", cbItem.DataSource, "id"));
            lbItemName.DataBindings.Add(new Binding("Text", cbItem.DataSource, "name"));
            lbItemPrice.DataBindings.Add(new Binding("Text", cbItem.DataSource, "price"));
            lbItemDiscount.DataBindings.Add(new Binding("Text", cbItem.DataSource, "discount"));
            lbItemQuantity.DataBindings.Add(new Binding("Text", cbItem.DataSource, "quantity"));
            lbItemSold.DataBindings.Add(new Binding("Text", cbItem.DataSource, "sold"));
        }

        private void fillCbxCustomer()
        {
            cbCustomer.DataSource = CustomerBLL.getInstance().getCustomerList();
            cbCustomer.DisplayMember = "name";
            lbCustomerId.DataBindings.Add(new Binding("Text", cbCustomer.DataSource, "id"));
            lbCustomerName.DataBindings.Add(new Binding("Text", cbCustomer.DataSource, "name"));
            lbCustomerPhoneNumber.DataBindings.Add(new Binding("Text", cbCustomer.DataSource, "phoneNumber"));
            lbCustomerPoint.DataBindings.Add(new Binding("Text", cbCustomer.DataSource, "point"));
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Brand brand in brandList) { if (brand.Id == ((Item)cbItem.SelectedItem).Brand_id) { lbItemBrand.Text = brand.Name; break; } }
            foreach(Category cat in categoryList) { if (cat.Id == ((Item)cbItem.SelectedItem).Category_id) { lbItemCategory.Text = cat.Name; break; } }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int n = (int)nudQuantity.Value;
            Item item = (Item)cbItem.SelectedItem;
            if (n > 0)
            {
                foreach(OrderDetail od in orderDetailList) 
                {
                    if (od.Item_id == item.Id) 
                    {
                        if(n + od.Quantity <= ItemBLL.getInstance().getItemQuantity(item.Id))
                        {
                            od.Quantity += n;
                            int priceDiscount = (int)((float)item.Price * ((float)item.Discount / 100f));
                            od.Total_price += (item.Price - priceDiscount) * n;
                            order_total += (item.Price - priceDiscount) * n;
                            calcLastPrice();
                            dgvOrderDetail.DataSource = null;
                            dgvOrderDetail.DataSource = orderDetailList;
                        }
                        else
                        {
                            MessageBox.Show("Không đủ số lượng");
                        }
                        return;
                    }
                }
                if(n <= ItemBLL.getInstance().getItemQuantity(item.Id))
                {
                    int priceDiscount = (int)((float)item.Price * ((float)item.Discount / 100f));
                    orderDetailList.Add(new OrderDetail(item.Id, item.Name, lbItemBrand.Text, item.Price, item.Discount, n, (item.Price - priceDiscount) * n));
                    order_total += (item.Price - priceDiscount) * n;
                    calcLastPrice();
                    dgvOrderDetail.DataSource = null;
                    dgvOrderDetail.DataSource = orderDetailList;
                }
                else
                    MessageBox.Show("Không đủ số lượng");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int itemId = ((OrderDetail)dgvOrderDetail.SelectedRows[0].DataBoundItem).Item_id;
            foreach (OrderDetail od in orderDetailList)
            {
                if (itemId == od.Item_id)
                {
                    dgvOrderDetail.DataSource = null;
                    orderDetailList.Remove(od);
                    dgvOrderDetail.DataSource = orderDetailList;
                    int priceDiscount = (int)((float)od.Price * ((float)od.Discount / 100f));
                    order_total -= (od.Price - priceDiscount) * od.Quantity;
                    calcLastPrice();
                    break;
                }
            }
        }

        private void btnItemDetail_Click(object sender, EventArgs e)
        {
            new LaptopForm((Item)cbItem.SelectedItem, LaptopForm.Mode.SHOWING).ShowDialog();
        }

        private void checkboxUsePoint_CheckedChanged(object sender, EventArgs e)
        {
            calcLastPrice();
        }

        private void calcLastPrice()
        {
            int discount = (int)((float)order_total * (float)nudDiscount.Value / 100f);
            order_lastPrice = order_total - discount;

            usedPoint = 0;
            if (checkboxUsePoint.Checked)
            {
                int point = ((Customer)cbCustomer.SelectedItem).Point;
                if (point >= order_lastPrice)
                {
                    usedPoint = order_lastPrice;
                    order_lastPrice = 0;
                }
                else
                {
                    order_lastPrice -= point;
                    usedPoint = point;
                }
            }
            lbOrderTotal.Text = order_total.ToString();
            lbOrderDiscount.Text = discount == 0 ? "0" : "-" + discount;
            lbOrderUsePoint.Text = usedPoint == 0 ? "0" : "-" + usedPoint;
            lbOrderLastPrice.Text = order_lastPrice.ToString();
            point_add = (int)((float)order_lastPrice * 0.025);
            lbOrderAddPoint.Text = point_add.ToString();
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            calcLastPrice();
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcLastPrice();
        }

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOrderConfirm_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)cbCustomer.SelectedItem;
            Order order = new Order(customer.Id, userId, tbOrderAddress.Text, (int)nudDiscount.Value, usedPoint, point_add, order_lastPrice);
            if(OrderBLL.getInstance().addOrder(order, orderDetailList))
            {
                MessageBox.Show("Thêm thành công");
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");

            }
        }
    }
}
