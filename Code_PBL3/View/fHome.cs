using Code_PBL3.DAO;
using Code_PBL3.DTO;
using Code_PBL3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Code_PBL3
{
    public partial class fHome : Form
    {
        private Form currentFormChild;
        private int idAcc;

        public int IdAcc
        {
            get { return idAcc; }
            set
            {
                idAcc = value;
            }
        }
        public fHome(int id)
        {
            InitializeComponent();
            this.IdAcc = id;
            ChangeAaccount();
        }
        public void OpenFormChild(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close(); 
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.TopMost = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.AutoScroll = true;
            childForm.AutoSize = true;
            pnl_Form.Controls.Add(childForm);
            childForm.Show();
        }
        #region Methods
        void ChangeAaccount()
        {
            Account a = AccountDAO.Instance.GetAccountByID(IdAcc);
            btManager.Enabled = a.Type == 1;
            btStatistic.Enabled = a.Type == 1;
            lbDisplayName.Text = a.UserName + "    : "+ a.DisPlayName  ;
        }
        #endregion
        #region Events
        private void fHome_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            lbTimer.Text = DateTime.Now.ToString();
        }    
        private void btHome_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        private void btSale_Click(object sender, EventArgs e)
        {
            OpenFormChild(new fSale(this.IdAcc));
        }

        private void btManager_Click(object sender, EventArgs e)
        {
            OpenFormChild(new fManagers(this.IdAcc));
        }
        private void btStatistic_Click(object sender, EventArgs e)
        {
            OpenFormChild(new fStatic());
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban có thật sự muốn thoát phần mềm ???", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = DateTime.Now.ToString();
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            OpenFormChild(new fSetting(this.IdAcc));
        }

        #endregion

        private void pnl_Form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fDetachedBill fx = new fDetachedBill();
            fx.Show();
        }
    }
}
