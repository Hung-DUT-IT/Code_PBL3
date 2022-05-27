using Code_PBL3.BUS;
using Code_PBL3.DAO;
using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_PBL3
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        #region Events
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassWord.Text;
            if (AccountBUS.Instance.Login(username, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                fHome f = new fHome(loginAccount.IdAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu~!! ");
            }
        }
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban có thật sự muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
