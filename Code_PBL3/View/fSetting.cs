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
    public partial class fSetting : Form
    {
        private int idAccount;
        public int AccountID
        {
            get { return idAccount; }
            set { idAccount = value; }
        }
        public fSetting(int id)
        {
            InitializeComponent();
            this.AccountID = id;
            LoadStaff();
            LoadAccount();
        }
        void LoadStaff()
        {
            Staff st = StaffDAO.Instance.GetStaffByIDAcc(this.AccountID);
            txbIdStaff.Text = st.IdStaff.ToString();
            txbPosition.Text = st.Position.ToString();
            txbNamestaff.Text = st.NameStaff.ToString();
            txbPhone.Text = st.Phone.ToString();
            txbShift.Text = st.Shift.ToString();
        }
        void LoadAccount()
        {
            Account ac = AccountDAO.Instance.GetAccountByID(this.AccountID);
            txbIdAccount.Text = ac.IdAccount.ToString();
            txbUserName.Text = ac.UserName.ToString();
            txbPass.Text = ac.PassWord.ToString();
            txbDisplayName.Text = ac.DisPlayName.ToString();
            if (ac.Type == 1)
            {
                txbTypeAccount.Text = "Tài Khoản Loại Quản Lý"; 
            }
            else txbTypeAccount.Text = "Tài Khoản Loại";
        }
        private void tabPInformationStaff_Click(object sender, EventArgs e)
        {
           
        }
    }
}
