using Code_PBL3.DAO;
using Code_PBL3.DTO;
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
        private int idaAcc;

        public int IdAcc
        {
            get { return idaAcc; }
            set
            {
                idaAcc = value;
            }
        }
        public fHome(int id)
        {
            InitializeComponent();
            this.IdAcc = id;
            ChangeAaccount();
        }
        #region Methods
        void ChangeAaccount()
        {
            Account a = AccountDAO.Instance.GetAccountByID(IdAcc);
            btManager.Enabled = a.Type == 1;
            btStatistic.Enabled = a.Type == 1;
            lbDisplayName.Text = a.UserName + " : "+ a.DisPlayName  ;
        }
        #endregion
        private void fHome_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            lbTimer.Text = DateTime.Now.ToString();
        }    
        private void btHome_Click(object sender, EventArgs e)
        {

        }

        private void btSale_Click(object sender, EventArgs e)
        {
            fSale f1 = new fSale(this.IdAcc) { TopLevel = false, TopMost = true };
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
            f1.AutoScroll = true;
            f1.AutoSize = true;
            pnl_Form.Controls.Add(f1);
            f1.Show();
        }

        private void btManager_Click(object sender, EventArgs e)
        {
           //aaa
        }

        private void btStatistic_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimer.Text = DateTime.Now.ToString();
        }
    }
}
