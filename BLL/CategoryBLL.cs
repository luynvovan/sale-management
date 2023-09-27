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
    public class CategoryBLL
    {
        private CategoryBLL() { }

        private static CategoryBLL instance = null;

        public static CategoryBLL getInstance()
        {
            if (instance == null)
            {
                instance = new CategoryBLL();
            }
            return instance;
        }

        public void fillCbxCategory(ComboBox cbx)
        {
            cbx.DataSource = CategoryAccess.getInstance().getCategoryList();
            cbx.DisplayMember = "name";
            cbx.ValueMember = "id";
        }
        public List<Category> getCategryList()
        {
            return CategoryAccess.getInstance().getCategoryList();
        }
    }
}
