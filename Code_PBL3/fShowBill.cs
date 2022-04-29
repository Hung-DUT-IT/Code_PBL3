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
    public partial class fShowBill : Form
    {
        public delegate void Mydel(int id);
        public Mydel d { get; set; }
        private int idaAcc;

        public int IdAcc
        {
            get { return idaAcc; }
            set
            {
                idaAcc = value;
            }
        }
        private int idBill;

        public int IdBill
        {
            get { return idBill; }
            set
            {
                idBill = value;
            }
        }
        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
            }
        }
        private int  discount;
        public int Discount
        {
            get { return discount; }
            set
            {
                discount = value;
            }
        }
        public fShowBill(int idAcc,int idbill, double totalPrice, int discount)
        {
            InitializeComponent();
            this.IdAcc = idAcc;
            this.IdBill = idbill;
            this.TotalPrice = totalPrice;
            this.Discount = discount;
        }

        private void fShowBill_Load(object sender, EventArgs e)
        {
            lbIDAcc.Text = IdAcc.ToString();
            Bill bill = BillDAO.Instance.GetBillByIdBill(IdBill);
            lbNameTable.Text = TableDAO.Instance.GetNameTableByIdBill(IdBill).ToString();
            lbDateCheckIn.Text = bill.DateCheckIn.ToString();
            lbDateCheckOut.Text = DateTime.Now.ToString();
            lbTotalPrice.Text = this.TotalPrice.ToString();
            lbDissCount.Text = this.Discount.ToString();
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            lbTotalEnd.Text = finalTotalPrice.ToString();
            if(txbMoneyCus.Text == "")
            {
                lbRefund.Text = "0";
            }
        }

        private void fShowBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban có muốn in hóa đơn không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                // xuất ra file txt; 
                BillDAO.Instance.CheckOut(this.IdBill, this.Discount, (float)Convert.ToDouble(lbTotalEnd.Text));
                e.Cancel = false;
            }
            else
            {
                BillDAO.Instance.CheckOut(this.IdBill, this.Discount, (float)Convert.ToDouble(lbTotalEnd.Text));
                e.Cancel = false;
            }
        }
    }
}
