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
    public partial class ShowOrder : Form
    {
        public ShowOrder(int orderId)
        {
            InitializeComponent();

            Order order = OrderBLL.getInstance().getOrder(orderId);
            List<OrderDetail> orderDetailsList = OrderBLL.getInstance().getOrderDetailList(order.Id);
            dgvOrderDetail.DataSource = orderDetailsList;

            int ftotal = 0;
            foreach(OrderDetail detail in orderDetailsList)
            {
                ftotal += detail.Total_price;
            }
            int fdiscountPer = order.Discount;
            int fdiscountPrice = (int)((float)ftotal * (float)fdiscountPer / 100f);
            int fusedPoint = order.Point_use;
            int flast = ftotal - fusedPoint - fdiscountPrice;
            int faddPoint = order.Point_add;

            total.Text = ftotal.ToString();
            discount.Text = "-" + fdiscountPrice.ToString();
            discount_percent.Text = fdiscountPer.ToString();
            usedPoint.Text = "-" + fusedPoint.ToString();
            lastPrice.Text = flast.ToString();
            addPoint.Text = faddPoint.ToString();

            Customer cus = CustomerBLL.getInstance().getCustomer(order.Customer_id);
            User user = UserBLL.getInstance().getUserById(order.User_id);

            idCus.Text = cus.Id.ToString();
            cusName.Text = cus.Name;
            cusPhone.Text = cus.PhoneNumber;
            orderAddress.Text = order.Address;
            userId.Text = user.Id.ToString();
            userName.Text = user.Name;
            dateOrder.Text = order.Date_order;
            dateComplete.Text = order.Date_complete;
            status.Text = order.Order_status == 0 ? "Chuẩn bị" : order.Order_status == 1 ? "Hoàn thành" : "Hủy";
        }
    }
}
