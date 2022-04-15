using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_PBL3.DAO
{
    public class MenuBillDAO
    {
        private static MenuBillDAO instance;

        public static MenuBillDAO Instance
        {
            get { if (instance == null) instance = new MenuBillDAO(); 
                return MenuBillDAO.instance; }
            set { MenuBillDAO.instance = value; }
        }
        private MenuBillDAO() { }

        public List<MenuBill> GetListMenuByTable(int idbill)
        {
            List<MenuBill> listmenu = new List<MenuBill>();
            string query = "select f.name , bi.counts, f.price, f.price*bi.counts as TotalPrice  from (BillFor as bi inner join Bill as b on bi.IDBill = b.IdBill) inner join Food as f on bi.IDFood = f.IdFood where bi.IDBill= '" + idbill + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuBill menu = new MenuBill(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
