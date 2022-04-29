using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_PBL3.DTO
{
    public class Customer
    {
        private int idCus;
        public int IdCus
        {
            get { return idCus; }
            set { idCus = value; }
        }
        private string nameCus;
        public string NameCus
        {
            set { nameCus = value; }
            get { return nameCus; }
        }
        private string phone;
        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        private int point;
        public int Point
        {
            set { point = value; }
            get { return point; }
        }
        public Customer(int id , string name, string phone ,int point)
        {
            this.IdCus = id;
            this.NameCus = name;
            this.Phone = phone;
            this.Point = point;
        }
        public Customer(DataRow i )
        {
            this.IdCus = (int)i["IdCtm"];
            this.NameCus = i["Name"].ToString();
            this.Phone = i["Phone"].ToString();
            this.Point = (int)i["Point"];
        }
    }
}
