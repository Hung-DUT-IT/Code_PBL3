using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO();
                return TableDAO.instance;
            }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public static double TableWidth = 143;
        public static double TableHeight = 143;
        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public List<Table> LoadTableListByArea(string namearea)
        {
            List<Table> tablelist = new List<Table>();
            if(namearea == "All")
            {
                return tablelist = LoadTableList();
            }
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetTableListByArea  @namearea = '" + namearea +"'");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public string GetNameTableByIdBill(int idbill)
        {
            string name = "";
            string query = "select Name  from TableFood  inner join BIll on TableFood.IdTable = BIll.IdTable where IdBIll = " + idbill;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                name = item[0].ToString();
            }
            return name;
        }
        public void SwitchTable(int idtable1, int idtable2, int idAcc, DateTime checkIn)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 , @idAccount , @datecheckin ", new object[] { idtable1, idtable2, idAcc , checkIn });
        }
    }
}
