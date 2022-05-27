using Code_PBL3.DAO;
using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_PBL3.BUS
{
    public class CategoryBUS
    {
        private static CategoryBUS instance;
        public static CategoryBUS Instance
        {
            get
            {
                if (instance == null) instance = new CategoryBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private CategoryBUS() { }
        public void AddCategory(string name)
        {
            if (CategoryDAO.Instance.AddCategory(name))
            {
                MessageBox.Show("Thêm danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm danh mục món ăn không thành công ");
            }
        }
        public void UpdateCategory(int idCategory, string namecategory)
        {
            if (CategoryDAO.Instance.UpdateCategory(idCategory, namecategory))
            {
                MessageBox.Show("Cập nhật danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật danh mục món ăn không thành công ");
            }
        }
        public void DelCategory(int idCategory)
        {

            if (CategoryDAO.Instance.DeleteCategory(idCategory))
            {
                MessageBox.Show("Xóa danh mục món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa danh mục món ăn không thành công ");
            }
        }
        public List<Category> SearchCategoryByName(string name)
        {
            List<Category> listCategory = new List<Category>();
            listCategory = CategoryDAO.Instance.SearchCategoryByName(name);
            return listCategory;
        }
    }
}
