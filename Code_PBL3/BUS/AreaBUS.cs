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
    public class AreaBUS
    {
        private static AreaBUS instance;
        public static AreaBUS Instance
        {
            get
            {
                if (instance == null) instance = new AreaBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private AreaBUS() { }
        public void AddArea(string name)
        {
            if (AreaDAO.Instance.AddArea(name))
            {
                MessageBox.Show("Thêm khu vực thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm khu vực không thành công ");
            }
        }
        public void UpdateArea(int id, string name)
        {
            if (AreaDAO.Instance.UpdateArea(id, name))
            {
                MessageBox.Show("Cập nhật khu vực thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật khu vực không thành công ");
            }
        }
        public void DelArea(int id)
        {

            if (AreaDAO.Instance.DeleteArea(id))
            {
                MessageBox.Show("Xóa khu vực thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa khu vực không thành công \nKhu Vực Đang Hoạt Động");
            }
        }
        public List<Area> SearchAreayName(string name)
        {
            List<Area> listArea = new List<Area>();
            listArea = AreaDAO.Instance.SearchAreaByName(name);
            return listArea;
        }
    }
}
