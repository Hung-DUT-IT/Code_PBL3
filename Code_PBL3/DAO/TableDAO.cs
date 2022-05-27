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
        public bool AddTable(int idarea, string name, string status = "Trống", int isDelete = 0 )
        {
            string query = String.Format("insert into TableFood values ({0},'{1}',N'{2}',{3})", idarea, name, status, isDelete);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int idtable, int idarea, string name, string status, int isDelete)
        {

            string query = String.Format("update TableFood set IdArea = {0}, Name = '{1}' ,Status = N'{2}', Isdelete = {3}  where IdTable = {4} ", idarea, name, status, isDelete, idtable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int idtable )
        {
            string query = String.Format("update TableFood set Isdelete = 1 where IdTable = {0} ", idtable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Table> SearchTableByName(string name)
        {
            List<Table> list = new List<Table>();
            string query = string.Format("select * from TableFood where dbo.GetUnsignString(Name) like  '%' +  dbo.GetUnsignString('{0}') +'%' " , name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
    }
}
