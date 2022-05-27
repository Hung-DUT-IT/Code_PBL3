using Code_PBL3.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.BUS
{
    public class BillBUS
    {
        private static BillBUS instance;
        public static BillBUS Instance
        {
            get
            {
                if (instance == null) instance = new BillBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private BillBUS() { }
        public DataTable LoadListByDate(DateTime CheckIn, DateTime CheckOut)
        {
            return BillDAO.Instance.GetListBillByDate(CheckIn, CheckOut);
        }
        public DataTable LoadListByDateAndPage(DateTime CheckIn, DateTime CheckOut,int Page)
        {
            return BillDAO.Instance.GetListBillByDateAndPage(CheckIn, CheckOut, Page);
        }
    }
}
