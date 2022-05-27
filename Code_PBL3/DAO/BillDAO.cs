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
        public Bill GetBillByIdBill(int idbill)
        {
            Bill bill = null;
            string query = "select * from Bill where IdBIll = " + idbill;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                bill = new Bill(item);
                return bill;
            }
            return bill;
        }
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
        public void CheckOut(int idBill, int discount, float totalPrice)
        {
            string query = "UPDATE Bill Set Status = 1," + "Discount = " + discount + ", TotalPrice = " + totalPrice + " where idBill = " + idBill;
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void InsertBill(int idtable, int idAcc , DateTime checkOut )
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable , @idAc , @datecheckin  ", new object[] { idtable, idAcc , checkOut });
        }

        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkfrom , @checkto  ", new object[] { checkIn, checkOut });
        }
        public DataTable GetListBillByDateAndPage(DateTime checkIn, DateTime checkOut,int Page)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkfrom , @checkto , @page ", new object[] { checkIn, checkOut, Page });
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
        public bool updatecusonbill(string idbill,string idcus)
        {
            string query = "update bill set IdCtm =  where IdBill = ";
            int ressult = DataProvider.Instance.ExecuteNonQuery(query, new object[] {idbill, idcus});
            return ressult > 0;
        }
        public int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteSaclar("exec USP_GetNumBillByDate @checkIn , @checkOut ", new object[] { checkIn, checkOut });
        }

    }
}
