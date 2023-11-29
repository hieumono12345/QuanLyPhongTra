using QuanLyPhongTra.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTra.DTO
{
    public class BillCheckOut
    {        
        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        private string count;
        public string Count
        {
            get { return count; }
            set { count = value; }
        }
        private string untiPrice;
        public string UntiPrice
        {
            get { return untiPrice; }
            set { untiPrice = value; }
        }
        private string totalPrice;
        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        
        public BillCheckOut(string foodName, string count, string untiPrice, string totalPrice)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.UntiPrice = untiPrice;
            this.TotalPrice = totalPrice;
        }
        public BillCheckOut(DataRow row)
        {
            this.FoodName = (string)row["foodName"];
            this.Count = (string)row["count"];
            this.UntiPrice = (string)row["unitPrice"];
            this.TotalPrice = (string)row["totalPrice"];
        }


    }
}
