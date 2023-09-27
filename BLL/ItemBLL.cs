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
    public class ItemBLL
    {
        private ItemBLL() { }

        private static ItemBLL instance = null;

        public static ItemBLL getInstance()
        {
            if (instance == null)
            {
                instance = new ItemBLL();
            }
            return instance;
        }

        public void fillDgvItem(BindingSource itemList, string nameContains)
        {
            itemList.DataSource = ItemAccess.getInstance().getItemList(nameContains);
        }

        public List<Item> getItemList()
        {
            return ItemAccess.getInstance().getItemList("");
        }

        public Laptop getLaptop(int id)
        {
            return ItemAccess.getInstance().getLaptop(id);
        }

        public bool addLaptop(Item item, Laptop laptop)
        {
            return ItemAccess.getInstance().addLaptop(item, laptop);
        }

        public bool updateLaptop(Item item, Laptop laptop)
        {
            return ItemAccess.getInstance().updateLaptop(item, laptop);
        }

        public bool deleteLaptop(int id)
        {
            try
            {
                return ItemAccess.getInstance().deleteLaptop(id);
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public int getItemQuantity(int id)
        {
            return ItemAccess.getInstance().getItemQuantity(id);
        }
    }
}
