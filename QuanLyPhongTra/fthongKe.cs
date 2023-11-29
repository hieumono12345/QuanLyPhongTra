using DevExpress.XtraEditors;
using QuanLyPhongTra.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTra
{
    public partial class fthongKe : DevExpress.XtraEditors.XtraForm
    {
        private DateTime checkIn;
        private DateTime checkOut;
        public fthongKe(DateTime firstDate, DateTime secondDate)
        {
            this.checkIn = firstDate;
            this.checkOut = secondDate;
            InitializeComponent();
            LoadDataToChartBieuDo();
            LoadDataToChartPie();
            
        }

        
        public void LoadDataToChartBieuDo()
        {
            chartControlBieuDoCot.Series["DoanhThuCuaBan"].Points.Clear();
            DataTable dt = BillDAO.Instance.GetDataForBieuDo(checkIn, checkOut);
            foreach (DataRow row in dt.Rows)
            {
                int idTable = (int)Convert.ToDouble(row["idTable"].ToString());
                float totalFinal = (float)Convert.ToDouble(row["totalFinal"].ToString());
                string tableName = Convert.ToString(row["name"]);
                string DateCheckOut = Convert.ToString(row["DateCheckOut"]);
                string DateCheckIn = Convert.ToString(row["DateCheckIn"]);
                chartControlBieuDoCot.Series["DoanhThuCuaBan"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(tableName, totalFinal));
                chartControlBieuDoCot.Refresh();
            }
            chartControlBieuDoCot.Refresh();
            /*chartControlDTTheoBan.Series["TKDTTheoBan"].Points.Clear();
            DataTable dt = BillDAO.Instance.GetDataForBieuDo(checkIn, checkOut);
            //DataTable dtVC = busVaccine.getAllVaccine();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int idTable = (int)Convert.ToDouble(row["idTable"].ToString());
                float totalFinal = (float)Convert.ToDouble(row["totalFinal"].ToString());
                string tableName = Convert.ToString(row["name"]);
                string DateCheckOut = Convert.ToString(row["DateCheckOut"]);
                string DateCheckIn = Convert.ToString(row["DateCheckIn"]);
                chartControlDTTheoBan.Series["TKDTTheoBan"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(tableName, totalFinal));
                chartControlDTTheoBan.Refresh();*/
            /*
            string stringHanSD = row["HANSD"].ToString().Trim();
            DateTime HanSD = DateTime.Parse(stringHanSD);
            TimeSpan Time = HanSD.Subtract(DateTime.Now);
            int SoNgayConLai = Time.Days;//Bằng hạn sử dụng trừ ngày hiện tại
            if ((SoNgayConLai-NgayTinhHan) < 0)
            {
                string LoaiVC = row["LOAIVACCINE"].ToString().Trim();
                int SoLuong = int.Parse(row["SOLUONGCOSAN"].ToString());
                chartControlVCSHH.Series["BDVCSHH"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(LoaiVC, SoLuong));
                chartControlDTTheoBan.Refresh();
            }*/
            //}

            /*chartControlDTTheoBan.Refresh();*/
        }

        public void LoadDataToChartPie()
        {
            chartControlPie.Series["DoanhThu"].Points.Clear();
            DataTable dt = FoodDAO.Instance.getFoodAndCount(checkIn, checkOut);

            if (dt != null)
            {
                try
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string Ten = row["name"].ToString();
                        Ten = Ten.Trim();
                        int SoLuong = int.Parse(row["count"].ToString());
                        chartControlPie.Series["DoanhThu"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Ten, SoLuong));
                    }
                    chartControlPie.Refresh();
                    //chartControlLoaiVC.Series["BDLoaiVC"].LegendText = "#AXISLABEL";
                    foreach (DataRow row in dt.Rows)
                    {
                        string Ten = row["name"].ToString();
                        Ten = Ten.Trim();
                        int SoLuong = int.Parse(row["count"].ToString());
                        chartControlCotDoanhThu.Series["SoLuotMua"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Ten, SoLuong));
                    }
                    chartControlCotDoanhThu.Refresh();
                }
                catch (Exception ex) { }
            }
            /*chartControlPie.Series["DoanhThu"].Points.Clear();
            DataTable dt = BillDAO.Instance.GetDataForBieuDo(checkIn, checkOut);
            foreach (DataRow row in dt.Rows)
            {
                int idTable = (int)Convert.ToDouble(row["idTable"].ToString());
                float totalFinal = (float)Convert.ToDouble(row["totalFinal"].ToString());
                string tableName = Convert.ToString(row["name"]);
                string DateCheckOut = Convert.ToString(row["DateCheckOut"]);
                string DateCheckIn = Convert.ToString(row["DateCheckIn"]);
                chartControlPie.Series["DoanhThu"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(tableName, totalFinal));
                chartControlPie.Refresh();
            }
            chartControlBieuDoCot.Refresh();*/
        }
        private void fthongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panelControlPie.Visible = true;
            panelControlCot.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //panelControlPie.Visible = false;
            panelControlCot.Visible = true;
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            panelControlPie.Visible = true;
            //panelControlCot.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            panelControlCot.Visible = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panelControlCot.Visible = true;
        }

        private void panelControlCot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAA_Click(object sender, EventArgs e)
        {
            //panelControlCot.Visible = true;
            panelControlPie.Visible = false;
        }
    }
}
