using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTra.DTO
{
    public class BillInfo
    {
        private int foodId;
        public int FoodId
        {
            get { return foodId; }
            set { foodId = value; }
        }
        public int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private int billId;
        public int BillId
        {
            get { return billId; }
            set { billId = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public BillInfo(int id , int billId, int foodId, int count) 
        {
            this.iD = id;
            this.billId = billId;
            this.foodId = foodId;
            this.count = count;
        }

        public BillInfo (DataRow row) 
        {
            this.iD = (int)row["id"];
            this.billId = (int)row["idBill"];
            this.foodId = (int)row["idFood"];
            this.count = (int)row["count"];
        }

    }
}
