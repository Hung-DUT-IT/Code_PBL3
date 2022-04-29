using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Staff
    {
        private int idStaff;
        public int IdStaff
        {
            get { return idStaff; }
            set { idStaff = value; }
        }
        private string position;
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        private string nameStaff;
        public string NameStaff
        {
            get { return nameStaff; }
            set { nameStaff = value; }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string shift;
        public string Shift
        {
            get { return shift; }
            set { shift = value; }
        }
        public Staff(int id, string position, string name , string phone , string shift )
        {
            this.IdStaff = id;
            this.Position = position;
            this.NameStaff = name;
            this.Phone = phone;
            this.Shift = shift;
        }
        public Staff(DataRow i )
        {
            this.IdStaff = (int)i["IdStaff"];
            this.Position = i["Position"].ToString();
            this.NameStaff = i["Name"].ToString();
            this.Phone = i["Phone"].ToString();
            this.Shift = i["Shifts"].ToString();
        }
    }
}
