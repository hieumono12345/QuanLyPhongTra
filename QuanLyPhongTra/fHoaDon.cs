using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraReports.UI;
using QuanLyPhongTra.DAO;
using QuanLyPhongTra.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyPhongTra
{
    public partial class fHoaDon : Form
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
        
        public fHoaDon(float toTalPrice, float dicountPrice, float finalPrice, string date , string nameTable, int idBill )
        {
            InitializeComponent();
            
            this.Date = date;
            this.ToTalPrice = toTalPrice;
            this.DicountPrice = dicountPrice;
            this.FinalPrice = finalPrice;
            this.NameTable = nameTable;
            this.IdBill= idBill;
            //MessageBox.Show("," + ToTalPrice + "," + FinalPrice + "," + ToTalPrice + "," + Date + "," + NameTable + "," + IdBill);
            LoadDetailBill();
        }

        void LoadDetailBill()
        {
            dtgvListFood.DataSource = FoodDAO.Instance.GetFoodList(this.IdBill);
            txbNameTable.Text = this.NameTable;
            CultureInfo culture = new CultureInfo("vi-VN");
            blDisCount.Text = this.DicountPrice.ToString("c", culture);
            lbFinalPrice.Text = this.FinalPrice.ToString("c", culture);
            lbTotalPrice.Text = this.ToTalPrice.ToString("c", culture);
            txbDate.Text= this.Date.ToString();
        }
        private void label13_Click(object sender, EventArgs e)
        {
            FoodDAO.Instance.GetFoodList(9);
        }
       
        
        private Bitmap memoryimg;
        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        private void pdmtHoadon_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.pnHD.Width / 2), this.pnHD.Location.Y);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            BillRP billRP = new BillRP(toTalPrice,dicountPrice, finalPrice, Date, nameTable, idBill);
            this.Hide();
            billRP.CreateDocument();
            billRP.ShowPreview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sdt = "";
            sdt = txbSDT.Text;
            

        }
    }
}
