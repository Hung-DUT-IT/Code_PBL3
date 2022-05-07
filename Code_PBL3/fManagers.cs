using Code_PBL3.DAO;
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
    public partial class fManagers : Form
    {
        public fManagers()
        {
            InitializeComponent();
            LoadList();
            Binding();
        }
        void LoadList()
        {
            LoadAccount();
            loadStaff();
            LoadCategory();
            LoadFood();
            LoadTable();
            LoadArea();
        }
        #region Method
        void Binding()
        {
            AddAccountBiding();
        }
        void LoadAccount()
        {
            dgvAcount.DataSource = AccountDAO.Instance.LoadAccount();
        }
        void loadStaff()
        {
            dgvStaff.DataSource=StaffDAO.Instance.LoadStaff();
        }
        void LoadCategory()
        {
            dgvCategory.DataSource=CategoryDAO.Instance.GetListCategory();
        }
        void LoadFood()
        {
            dgvFood.DataSource=FoodDAO.Instance.GetListFood();
        }
        void LoadTable()
        {
            dgvTable.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadArea()
        {
            dgvArea.DataSource = AreaDAO.Instance.LoadTableList();
        }
        void AddAccountBiding()
        {
            txbIdAccount.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "IdAccount", true, DataSourceUpdateMode.Never));
            txbIDStaffInAc.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "IdStaff", true, DataSourceUpdateMode.Never));
            txbUserName.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbPass.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAccount.DataBindings.Add(new Binding("Value", dgvAcount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void AddAccount(string userName, string DisplayName, int Type,string pass)
        {
            if (AccountDAO.Instance.InsertAccount( userName, DisplayName, Type, pass) )
            {
                MessageBox.Show("Thêm tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm tài khoản không thành công ");
            }
            LoadAccount();
        }
        void UpadateAccount(string userName, string DisplayName, int Type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, Type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật tài khoản không thành công ");
            }
            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if (loginAcount.UserName.Equals(userName))
            {
                MessageBox.Show("Đây là chính bạn không thể xóa tài khoản này ~~~~~~ ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa tài khoản không thành công ");
            }
            LoadAccount();
        }
        #endregion
        #region Events TabAccount
        private void btShow_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void btAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string pass = txbPass.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            AddAccount(userName, displayName, type,pass);
        }
        private void btUpdateAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            int type = (int)nmTypeAccount.Value;
        }

        private void btDelAccount_Click(object sender, EventArgs e)
        {

        }

        private void btSearhAccount_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
