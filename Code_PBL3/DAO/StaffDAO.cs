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
    }

}
