using Code_PBL3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get
            {
                if (instance == null) instance = new StaffDAO();
                return StaffDAO.instance;
            }
            set { StaffDAO.instance = value; }
        }
        private StaffDAO() { }
        public Staff GetStaffByIDAcc(int idacc)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetStaffByIDAccount  @idacc = " + idacc);
            foreach (DataRow item in data.Rows)
            {
                return new Staff(item);
            }
            return null;
        }
        public List<Staff> LoadStaff()
        {
            List<Staff> staff = new List<Staff>();
            string query = "select * from Staff ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Staff staff1 = new Staff(item);
                staff.Add(staff1);
            }
            return staff;
        }
        public int GetMaxIDStaff()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteSaclar("select Max(IdStaff) from Staff");
            }
            catch
            {
                return 1;
            }   

        }
        public bool UpdateStafff(int  idStaff,string userName, string Positon, string Shift)
        {
            string query = string.Format("Update Staff set Position ='{0}',Name='{1}',Shifts='{2}' where idStaff ={3} ",Positon,userName,Shift,idStaff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteStaff(int idstaff)
        {
            string query = string.Format("delete Staff  where idStaff = {0} ", idstaff);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertStaff(string name ,string Phone , string Position,string Shift)
        {
            string query = string.Format("insert into Staff values ('{0}','{1}','{2}','{3}')", Position, name, Phone, Shift);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Staff> SearchStaffByName(string name)
        {
            List<Staff> list = new List<Staff>();
            string query = string.Format("select * from Staff where dbo.GetUnsignString(Name) like '%'+ dbo.GetUnsignString('{0}') + '%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }
            return list;
        }
    }

}
