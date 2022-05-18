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
            LoadList();
            Binding();
        }
        void LoadList()
        {
            LoadAccount();
            LoadStaff();
            LoadCategory();
            LoadFood();
            LoadTable();
            LoadArea();
            dgvStaff.DataSource = StaffList;
            dgvAcount.DataSource = AccountList;
            dgvCategory.DataSource = CategoryList;
            dgvFood.DataSource = FoodList;
            LoadCbbCate();
        }
        #region Method
        void Binding()
        {
            AddAccountBiding();
            AddStaffBiding();
            AddCategoryBiding();
            AddFoodBiding();
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
            dgvTable.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadArea()
        {
            dgvArea.DataSource = AreaDAO.Instance.LoadTableList();
        }
        void LoadCbbCate()
        {
            cbbNameCategory.Items.Clear();
            cbbNameCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbbNameCategory.DisplayMember = "NameCategory";
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
        void UpadateAccount(string userName, int Type)
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
            int idAcc = Convert.ToInt32(dgvAcount.SelectedRows[0].Cells["IdAccount"].Value);
            if (this.IdAcc.Equals(idAcc))
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
        List<Account> SearchAccByUserName(string usernam)
        {
            List<Account> listAcc = new List<Account>();
            listAcc = AccountDAO.Instance.SearchAccountByUserName(usernam);
            return listAcc;
        }
        void AddStaffBiding()
        {
            txbidStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "IdStaff", true, DataSourceUpdateMode.Never));
            txbPositionStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Position", true, DataSourceUpdateMode.Never));
            txbNameStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "NameStaff", true, DataSourceUpdateMode.Never));
            txbPhoneStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            txbShiftStaff.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Shift", true, DataSourceUpdateMode.Never));
        }
        void Update_Staff(int idStaff, string userName, string Positon, string Shitf)
        {
            if (StaffDAO.Instance.UpdateStafff(idStaff, userName, Positon, Shitf))
            {
                MessageBox.Show("Cập nhật nhân viên thành công ");
                LoadStaff();
             
            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật nhân viên không thành công ");
            }
        }
        void DelStafff(int idstaff)
        {
           
            if (StaffDAO.Instance.DeleteStaff(idstaff))
            {
                MessageBox.Show("Xóa nhân viên  thành công ");
                /*if (deleteStaff != null)
                    deleteStaff(this, new EventArgs());*/
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa nhân viên  không thành công ");
            }
            LoadStaff();
        }
        void AddStaff(string name, string Phone, string Position, string Shift)
        {
            if (StaffDAO.Instance.InsertStaff(name, Phone, Position, Shift))
            {
                MessageBox.Show("Thêm nhân viên thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm nhân viên không thành công ");
            }
            LoadStaff();

        }
        List<Staff> SearchStaffByName(string name)
        {
            List<Staff> listStaff = new List<Staff>();
            listStaff = StaffDAO.Instance.SearchStaffByName(name);
            return listStaff;
        }
        void AddCategoryBiding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "IDCategory", true, DataSourceUpdateMode.Never));
            txbNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "NameCategory", true, DataSourceUpdateMode.Never));
        }
        void AddCategory(string name)
        {
            if (CategoryDAO.Instance.AddCategory(name))
            {
                MessageBox.Show("Thêm danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm danh mục món ăn không thành công ");
            }
            LoadCategory();
        }
        void UpdateCategory(int idCategory, string namecategory)
        {
            if (CategoryDAO.Instance.UpdateCategory(idCategory, namecategory))
            {
                MessageBox.Show("Cập nhật danh mục món ăn thành công ");
                LoadCategory();

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật danh mục món ăn không thành công ");
            }
        }
        void DelCategory(int idCategory)
        {

            if (CategoryDAO.Instance.DeleteCategory(idCategory))
            {
                MessageBox.Show("Xóa danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa danh mục món ăn không thành công ");
            }
            LoadCategory();
        }
        void UpdateFood(int idfood,string name , int Idcategory,int price)
        {
            if(FoodDAO.Instance.UpdateFood(idfood,Idcategory,name,price))
            {
                MessageBox.Show("Cập nhật món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \n Cập nhật món ăn không thành công ");
            }
            LoadFood();
        }
        #endregion
        #region Events TabAccount
        private void btShow_Click(object sender, EventArgs e)
        {           
            dgvAcount.DataSource = AccountDAO.Instance.LoadAccount();
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
            UpadateAccount(userName, type);
        }

        private void btDelAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            DeleteAccount(userName);
        }

        private void btSearhAccount_Click(object sender, EventArgs e)
        {
            dgvAcount.DataSource = SearchAccByUserName(txbSearchAcount.Text);
        }
        #endregion

        #region Events Staff
        private void updateStaff_Click(object sender, EventArgs e)
        {
            int idStaff = Convert.ToInt32(txbidStaff.Text);
            string userName = txbNameStaff.Text;
            string Position = txbPositionStaff.Text;
            string Shift = txbShiftStaff.Text;
            Update_Staff(idStaff, userName, Position, Shift);
        }

        private void bntShow_Click(object sender, EventArgs e)
        {
           dgvStaff.DataSource = StaffDAO.Instance.LoadStaff();
        }
        private void btDelStaff_Click(object sender, EventArgs e)
        {
            int idstaff = Convert.ToInt32(txbidStaff.Text);
            DelStafff(idstaff);
            
        }
        private void bntSearchStaff_Click(object sender, EventArgs e)
        {
            dgvStaff.DataSource = SearchStaffByName(txbsearchStaff.Text);
        }

        private void bntAddStaff_Click(object sender, EventArgs e)
        {
            string name = txbNameStaff.Text;
            string phone = txbPhoneStaff.Text;
            string position = txbPositionStaff.Text;
            string shift = txbShiftStaff.Text;
            AddStaff(name, phone, position, shift);

        }

        #endregion
        #region Category
        private void btAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbNameCategory.Text;
            AddCategory(name);
        }
        private void btUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDCategory.Text);
            string name = txbNameCategory.Text;
            UpdateCategory(id, name);
        }
        private void btDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDCategory.Text);
            DelCategory(id);
        }
        #endregion
        #region Food
        void AddFoodBiding()
        {
            txbIDFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "IdFood", true, DataSourceUpdateMode.Never));
            txbNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "PriceFood", true, DataSourceUpdateMode.Never));
        }
        void AddFood(string name, int category, int price)
        {
            if (FoodDAO.Instance.AddFood(name,category, price))
            {
                MessageBox.Show("Thêm món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm món ăn không thành công ");
            }
            LoadFood();
        }
        void UpdateFood(int idfood, int foodcategory,  string name, int price)
        {
            if (FoodDAO.Instance.UpdateFood(idfood, foodcategory, name, price))
            {
                MessageBox.Show("Cập nhật món ăn thành công ");
                LoadFood();

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật món ăn không thành công ");
            }
        }
        void DelFood(int idfood)
        {

            if (FoodDAO.Instance.DeleteFood(idfood))
            {
                MessageBox.Show("Xóa món ăn thành công ");
                /*if (deleteStaff != null)
                    deleteStaff(this, new EventArgs());*/
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa món ăn không thành công ");
            }
            LoadFood();
        }
        #endregion
        #region Food
        private void btAddFood_Click(object sender, EventArgs e)
        {
            string name = txbNameFood.Text;
            int categoryiD = (cbbNameCategory.SelectedItem as Category).IDCategory;
            int price = Convert.ToInt32(nmFoodPrice.Value);
            AddFood(name, categoryiD, price);           
        }
        private void btUpdateFood_Click(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(txbIDFood.Text);
            string name = txbNameFood.Text;
            int price = Convert.ToInt32(nmFoodPrice.Value);
            int categoryiD = (cbbNameCategory.SelectedItem as Category).IDCategory;
            UpdateFood(idfood,name, categoryiD, price);
        }
        #endregion
    }
}
