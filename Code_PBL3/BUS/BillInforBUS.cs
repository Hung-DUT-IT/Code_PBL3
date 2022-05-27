using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.BUS
{
    public class BillInforBUS
    {
        private static BillInforBUS instance;
        public static BillInforBUS Instance
        {
            get
            {
                if (instance == null) instance = new BillInforBUS();
                return instance;
            }
            private set { instance = value; }
        }
        private BillInforBUS() { }
    }
}
