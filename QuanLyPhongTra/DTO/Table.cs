using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTra.DTO
{
    public class Table
    {
        public Table(int iD, string name, string status)
        {
            this.iD = iD;
            this.name = name;
            this.status = status;
        }

        public Table (DataRow row) //kieu du lieu DataRow
        {
            this.ID= (int)row["ID"];
            this.Name= (string)row["Name"].ToString();
            this.Status= (String)row["status"].ToString();
        }

        private int iD;
        public int ID { get { return iD; } set { iD = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }

        private string status;
        public string Status { get { return status; } set { status = value; } }
        
    }
}
