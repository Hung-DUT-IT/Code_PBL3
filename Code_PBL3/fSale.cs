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
                        btn.BackColor = Color.Bisque;
                        break;
                    default:
                        btn.BackColor = Color.Red;
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
                btn.BackColor = Color.FromArgb(255, 222, 173);
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
            }
            else
            {
                BillInforDAO.Instance.InssertBillInfor(idBill, foodID, count);
            }
            ShowBill(idBill);
            LoadTable();
        }
        private void Btn_ClickTable(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Table).IdTable;
            lbNameTable.Text = ((sender as Button).Tag as Table).NameTable;
            dgvBill.Tag = (sender as Button).Tag;
            ShowBill(BillDAO.Instance.GetUnCheckBillIDByTableID(TableID));
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Table table = dgvBill.Tag as Table;
            if (table == null )
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
                if (cus == null)
                {
                    MessageBox.Show("KH Chưa Tồn tại !! Vui Lòng Thêm Khách Hàng !!");
                }
                else
                {
                    fShowBill f1 = new fShowBill(this.IdAcc, idBill, totalPrice, discount);
                    f1.Show();
                    ShowBill(idBill);
                    LoadTable();
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
                if(cus == null )
                {
                    MessageBox.Show("KH Chưa Tồn tại");
                }
                else
                {
                    MessageBox.Show("KH Đã Tồn tại");
                    switch(cus.Point)
                    {
                        case 200:
                            nmDiscount.Value = 2;
                            break;
                        case 500:
                            nmDiscount.Value = 5;
                            break;
                        case 700:
                            nmDiscount.Value = 7;
                            break;
                    }
                    txbNameCus.Text = cus.NameCus.ToString();
                }
            }
        }
    }
}
