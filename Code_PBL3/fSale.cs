using Code_PBL3.DAO;
using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_PBL3
{
    public partial class fSale : Form
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
        public fSale(int id)
        {
            InitializeComponent();
            this.IdAcc = id;
            LoadTable();
            LoadCategory();
            LoadAreaToCBB();
            LoadCBBTable();
        }
        #region Method
        void LoadAreaToCBB()
        {
            cbbArea.Items.Add("All");
            foreach(string i in AreaDAO.Instance.LoadNameArea().Distinct())
            {
                cbbArea.Items.Add(i);
            }
            cbbArea.Text = "All";
        }
        void LoadTable(string nameArea = "All")
        {
            flpTable.Controls.Clear();            
            List<Table> tablelist = TableDAO.Instance.LoadTableListByArea(nameArea);
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = (int)TableDAO.TableWidth, Height = (int)TableDAO.TableHeight };
                btn.Text = item.NameTable + Environment.NewLine + item.Status;
                btn.Click += Btn_ClickTable;
                btn.Tag = item;
                btn.ForeColor = Color.Chocolate;
                btn.Font = new Font("Microsoft Sans Serif",14.25f, FontStyle.Bold);
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Beige;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
        void LoadCategory()
        {
            flpCategory.Controls.Clear();
            List<Category> ctlist = CategoryDAO.Instance.GetListCategory();
            foreach (Category item in ctlist)
            {
                Button btn = new Button() { Width = (int)CategoryDAO.CategoryWidth, Height = (int)CategoryDAO.CategoryHeight };
                btn.Text = item.NameCategory ;
                btn.Click += Btn_ClickCategory;
                //btn.fo
                btn.BackColor = Color.Chocolate ;
                btn.Tag = item;               
                flpCategory.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            List<MenuBill> listBillInfors = MenuBillDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            dgvBill.DataSource = listBillInfors;
            for (int i = 0; i < dgvBill.Rows.Count ; i++)
            {
                totalPrice += float.Parse(dgvBill.Rows[i].Cells["TotalPrice"].Value.ToString());
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }
       void LoadCBBTable()
        {
            cbbCTable.DataSource = TableDAO.Instance.LoadTableList();
            cbbCTable.DisplayMember = "NameTable";
        }
        #endregion
        #region Events
        private void Btn_ClickCategory(object sender, EventArgs e)
        {
            int idCategory = ((sender as Button).Tag as Category).IDCategory;
            flpFood.Controls.Clear();
            List<Food> foodlist = FoodDAO.Instance.GetListFoodByCategory(idCategory);
            foreach (Food item in foodlist)
            {
                Button btn = new Button() { Width = (int)FoodDAO.FoodWidth, Height = (int)FoodDAO.FoodHeight };
                btn.Text = item.NameFood + Environment.NewLine + item.PriceFood;
                btn.Click += btAddFood_Click;
                btn.Tag = item;
                btn.BackColor = Color.Transparent;
                flpFood.Controls.Add(btn);
            }

        }
        private void btAddFood_Click(object sender, EventArgs e)
        {
            Table table = dgvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy Chọn Bàn !!");
                return;
            }
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.IdTable);
            int foodID = ((sender as Button).Tag as Food).IDFood;
            int count = (int)nmCountFood.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.IdTable, this.IdAcc, DateTime.Now);
                BillInforDAO.Instance.InssertBillInfor(BillDAO.Instance.GetMaxBill(), foodID, count);
                ShowBill(BillDAO.Instance.GetMaxBill());
            }
            else
            {
                BillInforDAO.Instance.InssertBillInfor(idBill, foodID, count);
                ShowBill(idBill);
            }
            LoadTable();
        }
        private void Btn_ClickTable(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Table).IdTable;
            lbNameTable.Text = ((sender as Button).Tag as Table).NameTable;
            dgvBill.Tag = (sender as Button).Tag;
            int idbill = BillDAO.Instance.GetUnCheckBillIDByTableID(TableID);
            if(BillDAO.Instance.GetBillByIdBill(idbill) == null )
            {
                lbDateTimeCheckin.Text = "~~~";
            }
            else
            {
                lbDateTimeCheckin.Text = BillDAO.Instance.GetBillByIdBill(idbill).DateCheckIn.ToString();
            }
            ShowBill(idbill);
        }

        private void cbbArea_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cbbArea.SelectedItem == null)
                return;
            else
            {
                LoadTable(cbbArea.Text.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Table table = dgvBill.Tag as Table;
            if (table == null)
            {
                return;
            }
            Customer cus = CustomerDAO.Instance.GetCusByPhone(txbPhoneCus.Text.ToString());

            int TableID = table.IdTable;
            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(TableID);
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if (idBill != -1)
            {
                if (MessageBox.Show("Ban có chắc chắn muốn tính tiền không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    fShowBill f1 = new fShowBill(this.IdAcc, idBill, totalPrice, discount);
                    this.Hide();
                    f1.ShowDialog();
                    ShowBill(idBill);
                    LoadTable();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng chọn món");
            }
        }

        private void btSearchKH_Click(object sender, EventArgs e)
        {
            Customer cus = null;
            if (txbPhoneCus.Text == "")
            {
                return;
            }
            else
            {
                string phone = txbPhoneCus.Text.ToString();
                cus = CustomerDAO.Instance.GetCusByPhone(phone);
                if (cus == null)
                {
                    MessageBox.Show("KH Chưa Tồn tại");
                }
                else
                {
                    MessageBox.Show("KH Đã Tồn tại");
                    if (cus.Point >= 200 && cus.Point < 500)
                    {
                        nmDiscount.Value = 2;
                    }
                    else
                    {
                        if (cus.Point >= 500 && cus.Point < 700)
                        {
                            nmDiscount.Value = 5;
                        }
                        else
                        {
                            nmDiscount.Value = 7;
                        }
                    }
                    txbNameCus.Text = cus.NameCus.ToString();
                }
            }
        }
        private void btAddKH_Click(object sender, EventArgs e)
        {
            string Name = txbNameCus.Text.ToString();
            string Phone = txbPhoneCus.Text.ToString();
            if (Name == "" || Phone == "")
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin");
            }
            else
            {
                if (CustomerDAO.Instance.InserterCus(Name, Phone))
                {
                    MessageBox.Show("Khách Hàng Đã Được Them Vào Hệ Thống");
                }
            }
        }

        private void btSwitchTable_Click(object sender, EventArgs e)
        {
            int idTable1 = (dgvBill.Tag as Table).IdTable;
            int idTable2 = (cbbCTable.SelectedItem as Table).IdTable;
            if (MessageBox.Show(String.Format("Bạn có thực sự muốn chuyển bàn {0} qua bàn {1} ??", (dgvBill.Tag as Table).NameTable, (cbbCTable.SelectedItem as Table).NameTable), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(idTable1, idTable2, this.IdAcc, DateTime.Now);
                LoadTable();
            }
        }
        #endregion
    }
}
