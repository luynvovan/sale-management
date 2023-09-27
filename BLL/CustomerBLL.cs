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
    public class CustomerBLL
    {
        private CustomerBLL() { }

        private static CustomerBLL instance = null;

        public static CustomerBLL getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerBLL();
            }
            return instance;
        }

        public List<Customer> getCustomerList()
        {
            return CustomerAccess.getInstance().getCustomerList("");
        }
        public void fillDgvCustomer(BindingSource customerList, string nameContains)
        {
            customerList.DataSource = CustomerAccess.getInstance().getCustomerList(nameContains);
        }

        public bool addCustomer(Customer customer)
        {
            try
            {
                return CustomerAccess.getInstance().addCustomer(customer);
            }
            catch
            {
                return false;
            }
        }
        public bool updateCustomer(Customer customer)
        {
            try
            {
                return CustomerAccess.getInstance().updateCustomer(customer);
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCustomer(int id)
        {
            try
            {
                return CustomerAccess.getInstance().deleteCustomer(id);
            }
            catch
            {
                return false;
            }
        }
        public Customer getCustomer(int id)
        {
            return CustomerAccess.getInstance().getCustomer(id);
        }
    }
}
