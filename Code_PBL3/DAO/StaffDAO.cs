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
    }
}
