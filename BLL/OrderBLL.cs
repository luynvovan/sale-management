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
    public class OrderBLL
    {
        private OrderBLL() { }

        private static OrderBLL instance = null;

        public static OrderBLL getInstance()
        {
            if (instance == null)
            {
                instance = new OrderBLL();
            }
            return instance;
        }

        public void fillDgvSimpleOrder(DataGridView dgvOrder, string nameContains, int status)
        {
            dgvOrder.DataSource = OrderAccess.getInstance().getOrderSimpleList(nameContains, status);
        }

        public Order getOrder(int id)
        {
            return OrderAccess.getInstance().getOrder(id);
        }

        public bool addOrder(Order order, List<OrderDetail> orderDetailList)
        {
            try
            {
                int id = OrderAccess.getInstance().addOrder(order);
                OrderAccess.getInstance().addOrderDetail(orderDetailList, id);
            }
            catch { return false; }
            return true;
        }

        public bool completeOrder(int id)
        {
            try
            {
                return OrderAccess.getInstance().completeOrder(id);
            }
            catch { return false; }
        }

        public bool cancelOrder(int id)
        {
            try
            {
                return OrderAccess.getInstance().cancelOrder(id);
            }
            catch { return false; }
        }
        public List<OrderDetail> getOrderDetailList(int orderId)
        {
            return OrderAccess.getInstance().getOrderDetailList(orderId);
        }
    }
}
