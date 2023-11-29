using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTra.DTO
{
    public class Bill
    {
        /*public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut, int status, int discount = 0, string timeCheckIn, string timeCheckOut)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
            this.TimeCheckIn = timeCheckIn;
            this.TimeCheckOut = timeCheckOut;
        }*/

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.Status = (int)row["status"];

            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
            
            this.TimeCheckIn = row["timeCheckIn"].ToString();

            if(row["timeCheckOut"].ToString()!="")
                this.TimeCheckOut = row["timeCheckOut"].ToString();
        }

        private string timeCheckIn;
        public string TimeCheckIn
        {
            get { return timeCheckIn; }
            set { timeCheckIn = value; }
        }

        private string timeCheckOut;
        public string TimeCheckOut
        {
            get { return timeCheckOut; }
            set { timeCheckOut = value; }
        }

        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime? dateCheckOut;

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private DateTime? dateCheckIn;

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}