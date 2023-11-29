using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace QuanLyPhongTra.DTO
{
    public class Menu
    {
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
            get {  return totalPrice; } 
            set {  totalPrice = value; } 
        }

        private string foodName;
        public string FoodName 
        { 
            get { return foodName; } 
            set { foodName = value; } 
        }
        public Menu(string FoodName, float Pice, int count, float TotalPrice = 0)
        {
            this.FoodName = FoodName;
            this.TotalPrice = TotalPrice;
            this.Price = Pice;
            this.Count = count;

        }
        public Menu(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Count = (int)row["count"];

        }
    }
}
