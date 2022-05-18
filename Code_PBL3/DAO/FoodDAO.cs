using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }
        public static double FoodWidth = 148;
        public static double FoodHeight = 60;
        public List<Food> GetFoodByCategory(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where idCategory =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        public List<Food> GetListFoodByCategory(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where idFoodCategory = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        public bool AddFood(string name, int idcategory, int price)
        {
            string query = String.Format("insert into Food values ({0},'{1}',{2})", idcategory, name, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(int idfood,int idcate, string name, int price)
        {

            string query = String.Format("update Food set Name = '{0}', IdFoodCategory = {1} , Price = {2}  where IdFood = {3} ", name, idcate, price, idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            string query = String.Format("delete Food where IdFood = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
