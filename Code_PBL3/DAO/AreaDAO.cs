using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class AreaDAO
    {
        private static AreaDAO instance;
        public static AreaDAO Instance
        {
            get
            {
                if (instance == null) instance = new AreaDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private AreaDAO() { }
        public List<Area> LoadAreaList()
        {
            List<Area> arealist = new List<Area>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetAreaList");
            foreach (DataRow item in data.Rows)
            {
                Area area = new Area(item);
                arealist.Add(area);
            }
            return arealist;
        }
        public List<string> LoadNameArea()
        {
            List<string> listName = new List<string>();
            foreach (Area item in LoadAreaList())
            {
                listName.Add(item.NameArea);
            }
            return listName;
        }
        public bool AddArea(string name)
        {
            string query = String.Format("insert into Area values ('{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateArea(int id, string name)
        {
            string query = String.Format("update Area set Name = '{0}' where IdArea = {1} ", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteArea(int id)
        {
            string query = String.Format("exec USP_DeleteTableAndBill @idArea = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Area> SearchAreaByName(string Name)
        {
            List<Area> list = new List<Area>();
            string query = string.Format("select * from Area where dbo.GetUnsignString(Name) like '%'+ dbo.GetUnsignString('{0}') + '%'", Name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Area area = new Area(item);
                list.Add(area);
            }
            return list;
        }
    }
}
