using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.BUS
{
    public class MenuBillBUS
    {
        private static MenuBillBUS instance;
        public static MenuBillBUS Instance
        {
            get
            {
                if (instance == null) instance = new MenuBillBUS();
                return instance;
            }
            private set { instance = value; }
        }
    }
}
