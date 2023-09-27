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
    public class BrandBLL
    {
        private BrandBLL() { }

        private static BrandBLL instance = null;

        public static BrandBLL getInstance()
        {
            if (instance == null)
            {
                instance = new BrandBLL();
            }
            return instance;
        }

        public void fillCbxBrand(ComboBox cbx)
        {
            cbx.DataSource = BrandAccess.getInstance().getBrandList("");
            cbx.DisplayMember = "name";
            cbx.ValueMember = "id";
        }

        public List<Brand> getBrandList()
        {
            return BrandAccess.getInstance().getBrandList("");
        }

        public bool addBrand(string name)
        {
            if(name == "")
                return false;
            return BrandAccess.getInstance().addBrand(name);
        }

        public bool deleteBrand(int id)
        {
            try
            {
                return BrandAccess.getInstance().deleteBrand(id);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool updateBrand(Brand brand)
        {
            return BrandAccess.getInstance().updateBrand(brand);
        }

        public void fillDgvBrand(BindingSource brandList, string nameContains)
        {
            brandList.DataSource = BrandAccess.getInstance().getBrandList(nameContains);
        }
    }
}
