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
    public partial class fManagers : Form
    {
        BindingSource AccountList = new BindingSource();
        BindingSource StaffList = new BindingSource();
        BindingSource CategoryList = new BindingSource();
        BindingSource FoodList = new BindingSource();
        BindingSource TableList = new BindingSource();
        BindingSource AreaList = new BindingSource();
        private int idAcc;
        public int IdAcc
        {
            get { return idAcc; }
            set { idAcc = value; }
        }
            
        public fManagers(int idAcc)
        {
            InitializeComponent();
            this.IdAcc = idAcc;
            LoadDGV();
            LoadListBinding();
            Binding(); 
        }
        #region Method
        void LoadListBinding()
        {
            LoadAccount();
            LoadStaff();
            LoadCategory();
            LoadFood();
            LoadTable();
            LoadArea();           
            LoadCbbCate();
            LoadCBBAreaTableFood();
            LoadCBBIsDeleteTable();
        }
        void LoadDGV()
        {
            dgvStaff.DataSource = StaffList;
            dgvAcount.DataSource = AccountList;
            dgvCategory.DataSource = CategoryList;
            dgvFood.DataSource = FoodList;
            dgvTable.DataSource = TableList;
            dgvArea.DataSource = AreaList;
        }
        void Binding()
        {
            AddAccountBiding();
            AddStaffBiding();
            AddCategoryBiding();
            AddFoodBiding();
            AddTableBiding();
            AddAreaBiding();
        }
        void LoadAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.LoadAccount();
        }
        void LoadStaff()
        {
            StaffList.DataSource = StaffDAO.Instance.LoadStaff();
        }
        void LoadCategory()
        {
            CategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadFood()
        {
            FoodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void LoadTable()
        {
            TableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadArea()
        {
            AreaList.DataSource = AreaDAO.Instance.LoadAreaList();
        }
        void LoadCbbCate()
        {
            cbbNameCategory.Items.Clear();
            cbbNameCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbbNameCategory.DisplayMember = "NameCategory";
        }
        void LoadCBBAreaTableFood()
        {
            cbbArea.DataSource = AreaDAO.Instance.LoadAreaList();
            cbbArea.DisplayMember = "NameArea";          
        }
        void LoadCBBIsDeleteTable()
        {
            cbbIsDelete.Items.Clear();
            cbbIsDelete.Items.Add("Đã Xóa");
            cbbIsDelete.Items.Add("Chưa Xóa");
            cbbIsDelete.SelectedIndex = 1;
        }
        #endregion
        #region AddBinding
        void AddAccountBiding()
        {
            txbIdAccount.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "IdAccount", true, DataSourceUpdateMode.Never));
            txbIDStaffInAc.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "IdStaff", true, DataSourceUpdateMode.Never));
            txbUserName.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbPass.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvAcount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAccount.DataBindings.Add(new Binding("Value", dgvAcount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }                  
        void AddStaffBiding()
        {
            txbidStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "IdStaff", true, DataSourceUpdateMode.Never));
            txbPositionStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Position", true, DataSourceUpdateMode.Never));
            txbNameStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "NameStaff", true, DataSourceUpdateMode.Never));
            txbPhoneStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            txbShiftStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Shift", true, DataSourceUpdateMode.Never));
        }
       
        void AddCategoryBiding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "IDCategory", true, DataSourceUpdateMode.Never));
            txtNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "NameCategory", true, DataSourceUpdateMode.Never));
        }
        void AddFoodBiding()
        {
            txbIDFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "IdFood", true, DataSourceUpdateMode.Never));
            txbNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "PriceFood", true, DataSourceUpdateMode.Never));          
        }
        void AddTableBiding()
        {
            txbIdTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "IdTable", true, DataSourceUpdateMode.Never));
            txbNameTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "NameTable", true, DataSourceUpdateMode.Never));
            txbStatusTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }
        void AddAreaBiding()
        {
            txbIdArea.DataBindings.Add(new Binding("Text", dgvArea.DataSource, "IdArea", true, DataSourceUpdateMode.Never));
            txbNameArea.DataBindings.Add(new Binding("Text", dgvArea.DataSource, "NameArea", true, DataSourceUpdateMode.Never));
        }
        #endregion
        #region Events TabAccount
        private void btShow_Click_1(object sender, EventArgs e)
        {
            dgvAcount.DataSource = AccountDAO.Instance.LoadAccount();
            LoadAccount();
        }

        private void btAddAccount_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string pass = txbPass.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            AccountBUS.Instance.AddAccount(userName, displayName, type, pass);
            LoadAccount();
        }

        private void btUpdateAccount_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            int type = (int)nmTypeAccount.Value;
            AccountBUS.Instance.UpadateAccount(userName, type);
            LoadAccount();
        }

        private void btDelAccount_Click_1(object sender, EventArgs e)
        {
            int idAcc = Convert.ToInt32(dgvAcount.SelectedRows[0].Cells["IdAccount"].Value);
            if (this.IdAcc.Equals(idAcc))
            {
                MessageBox.Show("Đây là chính bạn không thể xóa tài khoản này ~~~~~~ ");
                return;
            }
            else
            {
                int idac = Convert.ToInt32(txbIdAccount.Text);
                AccountBUS.Instance.DeleteAccount(idac);
            }
            LoadAccount(); 
        }

        private void btSearhAccount_Click_1(object sender, EventArgs e)
        {
            dgvAcount.DataSource = AccountBUS.Instance.SearchAccByUserName(txbSearchAcount.Text);
            LoadAccount(); 
        }
        #endregion
        #region Events TabStaff
        private void bntAddStaff_Click_1(object sender, EventArgs e)
        {
            string name = txbNameStaff.Text;
            string phone = txbPhoneStaff.Text;
            string position = txbPositionStaff.Text;
            string shift = txbShiftStaff.Text;
            StaffBUS.Instance.AddStaff(name, phone, position, shift);
            LoadStaff();
        }

        private void updateStaff_Click_1(object sender, EventArgs e)
        {
            int idStaff = Convert.ToInt32(txbidStaff.Text);
            string userName = txbNameStaff.Text;
            string Position = txbPositionStaff.Text;
            string Shift = txbShiftStaff.Text;
            StaffBUS.Instance.Update_Staff(idStaff, userName, Position, Shift);
            LoadStaff(); 
        }

        private void btDelStaff_Click_1(object sender, EventArgs e)
        {
            int idstaff = Convert.ToInt32(txbidStaff.Text);
            StaffBUS.Instance.DelStafff(idstaff);
            LoadStaff();
        }

        private void bntShow_Click_1(object sender, EventArgs e)
        {
            dgvStaff.DataSource = StaffDAO.Instance.LoadStaff();
            LoadStaff(); 
        }

        private void bntSearchStaff_Click_1(object sender, EventArgs e)
        {
            dgvStaff.DataSource = StaffBUS.Instance.SearchStaffByName(txbsearchStaff.Text);
            LoadStaff();
        }
        #endregion
        #region Events TabCategory
        private void btAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtNameCategory.Text;
            CategoryBUS.Instance.AddCategory(name);
            LoadCategory();
        }

        private void btUpdateCategory_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(txbIDCategory.Text);
            string name = txtNameCategory.Text;
            CategoryBUS.Instance.UpdateCategory(idcategory, name);
            LoadCategory();
        }

        private void btDeleteCategory_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(txbIDCategory.Text);
            CategoryBUS.Instance.DelCategory(idcategory);
            LoadCategory();
        }
        private void btnSearchCategory_Click_1(object sender, EventArgs e)
        {
            string name = txbSearchCategory.Text;
            dgvCategory.DataSource = CategoryBUS.Instance.SearchCategoryByName(name);
            LoadCategory();
        }
        #endregion
        #region Events TabFood
        private void btAddFood_Click_1(object sender, EventArgs e)
        {
            string name = txbNameFood.Text;
            int categoryiD = (cbbNameCategory.SelectedItem as Category).IDCategory;
            int price = Convert.ToInt32(nmFoodPrice.Value);
            FoodBUS.Instance.AddFood(name, categoryiD, price);
            LoadFood();
        }

        private void btUpdateFood_Click_1(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txbIDFood.Text);
            string name = txbNameFood.Text;
            int price = Convert.ToInt32(nmFoodPrice.Value);
            int categoryiD = (cbbNameCategory.SelectedItem as Category).IDCategory;
            FoodBUS.Instance.UpdateFood(idfood, categoryiD, name, price);
            LoadFood(); 
        }

        private void btDeleteFod_Click_1(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txbIDFood.Text);
            FoodBUS.Instance.DelFood(idfood);
            LoadFood();
        }
        private void btSearchF_Click(object sender, EventArgs e)
        {
            string name = txbSearchFood.Text;
            dgvFood.DataSource = FoodBUS.Instance.SearchAccByName(name);
            LoadFood();
        }

        #endregion
        #region Events TabTable
        private void btAddTable_Click(object sender, EventArgs e)
        {
            int idArea = (cbbArea.SelectedItem as Area).IDArea;
            string name = txbNameTable.Text;
            string status = txbStatusTable.Text;
            TableBUS.Instance.AddTable(idArea,name);
            LoadTable();
        }

        private void btUpdateTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbIdTable.Text);
            // lay tu cbb 
            int idArea = (cbbArea.SelectedItem as Area).IDArea ;
            string name = txbNameTable.Text;
            string status = txbStatusTable.Text;
            int isdelete;
            if (cbbIsDelete.SelectedIndex == 0 )
            {
                isdelete = 1;
            }
            else
            {
                isdelete = 0;
            }
            TableBUS.Instance.UpdateTable(idTable, idArea, name, status, isdelete);
            LoadTable(); ;
        }

        private void btDeleteTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbIdTable.Text);
            TableBUS.Instance.DelTable(idTable);
            LoadTable(); 
        }
        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            string name = txbSearchTable.Text;
            dgvTable.DataSource =TableBUS.Instance.SearchTableByName(name);
            LoadTable();
        }
        #endregion
        #region Events TabArea
        private void btAddArea_Click(object sender, EventArgs e)
        {
            string name = txbNameArea.Text;
            AreaBUS.Instance.AddArea(name);
            LoadArea();
        }

        private void btUpdateArea_Click(object sender, EventArgs e)
        {
            int idArea = Convert.ToInt32(txbIdArea.Text);
            string name = txbNameArea.Text;
            AreaBUS.Instance.UpdateArea(idArea, name);
            LoadArea();
        }

        private void btDeleteArea_Click(object sender, EventArgs e)
        {
            int idArea = Convert.ToInt32(txbIdArea.Text);
            AreaBUS.Instance.DelArea(idArea);
            LoadArea();
        }
        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            string name = txbSearchArea.Text;
            dgvArea.DataSource = AreaBUS.Instance.SearchAreayName(name);
            LoadArea();
        }
        #endregion
    }
}
