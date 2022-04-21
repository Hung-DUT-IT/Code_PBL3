using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Area
    {
        private int idArea;
        public int IDArea
        {
            get { return idArea; }
            set { idArea = value; }
        }
        private string nameArea;
        public string NameArea
        {
            get { return nameArea; }
            set { nameArea = value; }
        }
        public Area(int id, string name)
        {
            this.IDArea = id;
            this.NameArea = name;
        }
        public Area(DataRow row)
        {
            this.IDArea = (int)row["IdArea"];
            this.NameArea = row["Name"].ToString();
        }
    }
}
