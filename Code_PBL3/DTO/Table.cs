using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Table
    {
        private int idTable;
        public int IdTable
        {
            get { return idTable; }
            set { idTable = value; }
        }
        private string nameTable;
        public string NameTable
        {
            get { return nameTable; }
            set { nameTable = value; }
        }
        private int idArea;
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public Table(int id, string name, int are, string status)
        {
            this.IdTable = id;
            this.NameTable = name;
            this.IdArea = are;
            this.Status = status;
        }
        public Table(DataRow row)
        {
            this.IdTable = (int)row["IdTable"];
            this.NameTable = row["Name"].ToString();
            this.IdArea = (int)row["IdArea"];
            this.Status = row["Status"].ToString();
        }
    }
}
