using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public  class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO(); return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUnCheckBillIDByTableID(int idtable)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Bill where IdTable = '" + idtable +"' " + "And Status = 0 ");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IdBill;
            }
            return -1;
        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE Bill Set DateCheckOut = GetDate(), status = 1," + "discount = " + discount + ", totalPrice = " + totalPrice + " where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void InsertBill(int idtable, int idAcc , DateTime checkOut )
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable , @idAc , @datecheckin  ", new object[] { idtable, idAcc , checkOut });
        }

        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut , ", new object[] { checkIn, checkOut });
        }
        public int GetMaxBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteSaclar("select Max(IdBill) from Bill");
            }
            catch
            {
                return 1;
            }

        }
    }
}
