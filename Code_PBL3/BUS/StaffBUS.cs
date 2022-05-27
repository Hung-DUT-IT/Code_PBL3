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
    public class StaffBUS
    {
        private static StaffBUS instance;
        public static StaffBUS Instance
        {
            get
            {
                if (instance == null) instance = new StaffBUS();
                return instance;
            }
            private set { instance = value; }
        }
        public void Update_Staff(int idStaff, string userName, string Positon, string Shitf)
        {
            if (StaffDAO.Instance.UpdateStafff(idStaff, userName, Positon, Shitf))
            {
                MessageBox.Show("Cập nhật nhân viên thành công ");

            }
            else
            {
                MessageBox.Show("ERROR !!! \nCập nhật nhân viên không thành công ");
            }
        }
        public void DelStafff(int idstaff)
        {

            if (StaffDAO.Instance.DeleteStaff(idstaff))
            {
                MessageBox.Show("Xóa nhân viên  thành công ");
                /*if (deleteStaff != null)
                    deleteStaff(this, new EventArgs());*/
            }
            else
            {
                MessageBox.Show("ERROR !!! \nXóa nhân viên  không thành công ");
            }
        }
        public void AddStaff(string name, string Phone, string Position, string Shift)
        {
            if (StaffDAO.Instance.InsertStaff(name, Phone, Position, Shift))
            {
                MessageBox.Show("Thêm nhân viên thành công ");
            }
            else
            {
                MessageBox.Show("ERROR !!! \nThêm nhân viên không thành công ");
            }

        }
        public List<Staff> SearchStaffByName(string name)
        {
            List<Staff> listStaff = new List<Staff>();
            listStaff = StaffDAO.Instance.SearchStaffByName(name);
            return listStaff;
        }

    }
}
