using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class MenuBill
    {
        private string foodName;

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private float totalPrice;
        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public MenuBill(string foodname, int count, float price, float totalprice = 0)
        {
            this.FoodName = foodname;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;
        }
        public MenuBill(DataRow row)
        {
            this.FoodName = row["name"].ToString();
            this.Count = (int)row["counts"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
    }
}
