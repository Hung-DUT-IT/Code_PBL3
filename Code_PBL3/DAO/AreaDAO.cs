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
        public List<Area> LoadTableList()
        {
            List<Area> tablelist = new List<Area>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetAreaList");
            foreach (DataRow item in data.Rows)
            {
                Area area = new Area(item);
                tablelist.Add(area);
            }
            return tablelist;
        }
        public List<string> LoadNameArea()
        {
            List<string> listName = new List<string>();
            foreach (Area item in LoadTableList())
            {
                listName.Add(item.NameArea);
            }
            return listName;
        }

    }
}
