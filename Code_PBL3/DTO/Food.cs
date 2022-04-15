using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Food
    {
        private int iDFood;

        public int IDFood
        {
            get { return iDFood; }
            set { iDFood = value; }
        }
        private string nameFood;
        public string NameFood
        {
            get { return nameFood; }
            set { nameFood = value; }
        }
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private float priceFood;

        public float PriceFood
        {
            get { return priceFood; }
            set { priceFood = value; }
        }
        public Food(int id, string name, int categoryid, float price)
        {
            this.IDFood = id;
            this.NameFood = name;
            this.CategoryID = categoryid;
            this.PriceFood = price;
        }
        public Food(DataRow row)
        {
            this.IDFood = (int)row["IdFood"];
            this.NameFood = row["Name"].ToString();
            this.CategoryID = (int)row["IdFoodCategory"];
            this.PriceFood = (float)Convert.ToDouble(row["Price"].ToString());
        }
    }
}
