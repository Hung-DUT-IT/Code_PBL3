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
    public class FoodBUS
    {
        private static FoodBUS instance;
        public static FoodBUS Instance
        {
            get
            {
                if (instance == null) instance = new FoodBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void UpdateFood(int idfood, int foodcategory, string name, int price)
        {
            if (FoodDAO.Instance.UpdateFood(idfood, foodcategory, name, price))
            {
                MessageBox.Show("Cập nhật món ăn thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật món ăn không thành công ");
            }
        }
        public void AddFood(string name, int category, int price)
        {
            if (FoodDAO.Instance.AddFood(name, category, price))
            {
                MessageBox.Show("Thêm món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm món ăn không thành công ");
            }
        }

        public void DelFood(int idfood)
        {

            if (FoodDAO.Instance.DeleteFood(idfood))
            {
                MessageBox.Show("Xóa món ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa món ăn không thành công ");
            }
        }
        public List<Food> SearchAccByName(string name)
        {
            List<Food> listFood = new List<Food>();
            listFood = FoodDAO.Instance.SearchAccountByName(name);
            return listFood;
        }
    }
}
