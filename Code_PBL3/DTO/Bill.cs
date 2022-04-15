using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    internal class Bill
    {
        private int iDBill;
        public int IdBill
        {
            get { return iDBill; }
            set { iDBill = value; }
        }
        private string iDTable ;
        public string IDTable
        {
            get { return iDTable; }
            set { iDTable = value; }
        }
        private string iDAccount;
        public string IDAccount
        {
            get { return iDAccount; }
            set { iDAccount = value; }
        }
        private string iDCtm;
        public string IDCtm
        {
            get { return iDCtm; }
            set { iDCtm = value; }
        }

        private string iDStaff;
        public string IDStaff
        {
            get { return iDStaff; }
            set { iDStaff = value; }
        }
        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        private int totalPrice ;
        public int TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public Bill(int idbill, string idtable,string idaccount, string idctm, string idstaff  , DateTime? datecheckin, int status, int discount = 0,int totalprice = 0 )
        {
            this.IdBill = idbill;
            this.IDTable = idtable;
            this.IDAccount = idaccount;
            this.IDCtm = idctm;
            this.IDStaff = idstaff;
            this.DateCheckIn = datecheckin;
            this.Status = status;
            this.Discount = discount;
            this.TotalPrice = totalprice;
        }
        public Bill(DataRow row)
        {
            this.IdBill = (int)row["IdBill"];
            this.IDTable = row["IdTable"].ToString();
            this.IDAccount = row["IdAccount"].ToString();
            this.IDCtm = row["IdCtm"].ToString();           
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            this.Status = (int)row["status"];
            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
            this.TotalPrice = (int)row["discount"];
        }
    }
}
