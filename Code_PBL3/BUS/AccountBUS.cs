using Code_PBL3.DAO;
using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_PBL3.BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance
        {
            get
            {
                if (instance == null) instance = new AccountBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private AccountBUS() { }
        public bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
        public void AddAccount(string userName, string DisplayName, int Type, string pass)
        {
            if (AccountDAO.Instance.InsertAccount(userName, DisplayName, Type, pass))
            {
                MessageBox.Show("Thêm tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm tài khoản không thành công ");
            }
        }
        public void UpadateAccount(string userName, int Type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, Type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật tài khoản không thành công ");
            }
        }
        public void DeleteAccount(int idac)
        {           
            if (AccountDAO.Instance.DeleteAccount(idac))
            {
                MessageBox.Show("Xóa tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa tài khoản không thành công ");
            }
        }
        public List<Account> SearchAccByUserName(string usernam)
        {
            List<Account> listAcc = new List<Account>();
            listAcc = AccountDAO.Instance.SearchAccountByUserName(usernam);
            return listAcc;
        }
    }
}
