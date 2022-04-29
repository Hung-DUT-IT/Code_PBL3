using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get 
            { 
                if (instance == null) instance = new AccountDAO(); 
                return instance; 
            }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {                    
            string query = "USP_LoginAccount @username = " + username + ", @password = '" + password + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string UserName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Account where UserName = '" + UserName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public Account GetAccountByID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Account where IdAccount = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
    }
}
