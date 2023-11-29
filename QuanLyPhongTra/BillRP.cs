using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace QuanLyPhongTra
{
    public partial class BillRP : DevExpress.XtraReports.UI.XtraReport
    {
        private int idBill;
        public int IdBill
        {
            get { return idBill; }
            set { idBill = value; }
        }

        private float toTalPrice;
        public float ToTalPrice
        {
            get { return toTalPrice; }
            set { toTalPrice = value; }
        }
        private float dicountPrice;
        public float DicountPrice
        {
            get { return dicountPrice; }
            set { dicountPrice = value; }
        }
        private float finalPrice;
        public float FinalPrice
        {
            get { return finalPrice; }
            set { finalPrice = value; }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string nameTable;
        public string NameTable
        {
            get { return nameTable; }
            set { nameTable = value; }
        }
        public BillRP(float toTalPrice, float dicountPrice, float finalPrice, string date, string nameTable, int idBill)
        {
            InitializeComponent();
            this.Date = date;
            this.ToTalPrice = toTalPrice;
            this.DicountPrice = dicountPrice;
            this.FinalPrice = finalPrice;
            this.NameTable = nameTable;
            this.IdBill = idBill;
            //MessageBox.Show("," + ToTalPrice + "," + FinalPrice + "," + ToTalPrice + "," + Date + "," + NameTable + "," + IdBill);
            LoadDetailBill();
        }
        void LoadDetailBill()
        {
            //dtgvListFood.DataSource = FoodDAO.Instance.GetFoodList(this.IdBill);
            tbNameTable.Text = this.NameTable;
            CultureInfo culture = new CultureInfo("vi-VN");
            tbDiscout.Text = this.DicountPrice.ToString("c", culture);
            tbFinalPrice.Text = this.FinalPrice.ToString("c", culture);
            tbTotal.Text = this.ToTalPrice.ToString("c", culture);
            xrBCIDBill.Text = idBill.ToString();
            //tbDate.Text = this.Date.ToString();
        }

        

    }
}
