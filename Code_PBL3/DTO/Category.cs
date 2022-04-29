using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Category
    {
        private int iDCategory;

        public int IDCategory
        {
            get { return iDCategory; }
            set { iDCategory = value; }
        }

        private string nameCategory;
        public string NameCategory
        {
            get { return nameCategory; }
            set { nameCategory = value; }
        }
        public Category(int id, string name)
        {
            this.IDCategory = id;
            this.NameCategory = name;
        }
        public Category(DataRow row)
        {
            this.IDCategory = (int)row["IdCtgr"];
            this.NameCategory = row["Name"].ToString();
        }
    }
}
