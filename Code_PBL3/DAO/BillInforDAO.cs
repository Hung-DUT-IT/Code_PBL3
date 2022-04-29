using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class BillInforDAO
    {
        private static BillInforDAO instance;

        public static BillInforDAO Instance
        {
            get { if (instance == null) instance = new BillInforDAO(); return BillInforDAO.instance; }
            set { BillInforDAO.instance = value; }
        }
        private BillInforDAO() { }
        public List<BillInfor> GetListBIllIfor(int id)
        {
            List<BillInfor> listBillinfor = new List<BillInfor>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from BillInfor where idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfor infor = new BillInfor(item);
                listBillinfor.Add(infor);
            }
            return listBillinfor;
        }
        public void InssertBillInfor(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfor @idBill , @idFood , @count", new object[] { idBill , idFood , count });
        }
        public void DeleteBillInforByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete BillInfor where idFood = " + id);
        }
    }
}
