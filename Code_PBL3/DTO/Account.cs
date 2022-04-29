using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Account
    {
        private int idAccount;
        public int IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }
        private int idStaff;
        public int IdStaff
        {
            get { return idStaff; }
            set { idStaff = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string disPlayName;
        public string DisPlayName
        {
            get { return disPlayName; }
            set { disPlayName = value; }
        }
        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public Account(int idac, int idstaff,string username, string displayname, int type, string password = null)
        {
            this.IdAccount = idac;
            this.IdStaff = idstaff;
            this.UserName = username;
            this.DisPlayName = displayname;
            this.PassWord = password;
            this.Type = type;
        }
        public Account(DataRow row)
        {
            this.IdAccount = (int)row["IdAccount"];
            this.IdStaff = (int)row["IdStaff"];
            this.UserName = row["UserName"].ToString();
            this.DisPlayName = row["DisplayName"].ToString();
            this.PassWord = row["Pass"].ToString();
            this.Type = (int)row["Type"];
        }
    }
}
