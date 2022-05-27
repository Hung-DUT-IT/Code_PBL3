using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public static double CategoryWidth = 160;
        public static double CategoryHeight = 60;
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category categorys = new Category(item);
                list.Add(categorys);
            }
            return list;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "select * from FoodCategory where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        public Category GetCategoryByName(string name)
        {
            Category cate = null;
            string query = String.Format("select * from FoodCategory where Name = '{0}'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                cate = new Category(item);
                return cate;
            }
            return cate;
        }
        public bool AddCategory(string name)
        {
            string query = String.Format("insert into FoodCategory values ('{0}')" , name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategory(int id,string name)
        {
            string query = String.Format("update FoodCategory set Name = '{0}' where IdCtgr = {1} " ,name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
       
        public List<Category> SearchCategoryByName(string Name)
        {
            List<Category> list = new List<Category>();
            string query = string.Format("select * from FoodCategory where dbo.GetUnsignString(Name) like '%'+ dbo.GetUnsignString('{0}') + '%'", Name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        public bool DeleteCategory(int id)
        {
           int result = DataProvider.Instance.ExecuteNonQuery("exec USP_DeleteFoodByCategory @idCategory", new object[] { id });
            return result > 0;
        }
    }
}
