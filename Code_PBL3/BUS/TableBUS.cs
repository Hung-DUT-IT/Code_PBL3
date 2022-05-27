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
    public class TableBUS
    {
        private static TableBUS instance;
        public static TableBUS Instance
        {
            get
            {
                if (instance == null) instance = new TableBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void AddTable(int idarea, string name)
        {
            if (TableDAO.Instance.AddTable(idarea, name))
            {
                MessageBox.Show("Thêm bàn ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm bàn ăn không thành công ");
            }
        }
        public void UpdateTable(int idtable, int idarea, string name, string status, int isDelete)
        {
            if (TableDAO.Instance.UpdateTable(idtable, idarea, name, status, isDelete))
            {
                MessageBox.Show("Cập nhật bàn ăn thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật bàn ăn không thành công ");
            }
        }
        public void DelTable(int id)
        {

            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn ăn thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa bàn ăn không thành công ");
            }
        }
        public List<Table> SearchTableByName(string name)
        {
            List<Table> listTable = new List<Table>();
            listTable = TableDAO.Instance.SearchTableByName(name);
            return listTable;
        }
    }
}
