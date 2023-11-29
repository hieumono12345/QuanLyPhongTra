
using DevExpress.CodeParser;
using DevExpress.DataProcessing;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using QuanLyPhongTra.DAO;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace QuanLyPhongTra.Report
{
    public class ThongKeRP_Provider
    {
        private DateTime checkIn;
        private DateTime checkOut;

        public DataSet.DataSet1 ds;
        public Report.ThongKeRP rp;

        public ThongKeRP_Provider(DateTime firstDate, DateTime secondDate)
        {
            this.checkIn = firstDate;
            this.checkOut = secondDate;
            this.ds = new DataSet.DataSet1();
            this.rp = new Report.ThongKeRP();

        }
        private void InsertData()
        {
            DataTable data = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    string tableName = Convert.ToString(row["Name"]);
                    string DateCheckOut = Convert.ToString(row["DateCheckIn"]);
                    string TimeCheckIn = Convert.ToString(row["TimeCheckIn"]);
                    string TimeCheckOut = Convert.ToString(row["TimeCheckOut"]);
                    string totalPrice = Convert.ToString(row["totalPrice"]);
                    string DisCount = Convert.ToString(row["Discount"]);
                    string IDBill = Convert.ToString(row["id"]);

                    ds.ThongKeRP_DataTable.Rows.Add(new object[] { tableName, DateCheckOut.Substring(0,9), TimeCheckIn, TimeCheckOut, totalPrice, DisCount, IDBill });
                }
            }
            DataTable data2 = BillDAO.Instance.GetResultForReportThongKe(checkIn, checkOut);
            if (data2 != null)
            {
                foreach (DataRow row in data2.Rows)
                {
                    float total = (float)Convert.ToDouble(row["total"].ToString());
                    float totalFinal = (float)Convert.ToDouble(row["totalFinal"].ToString());
                    float totalDiscount = (float)Convert.ToDouble(row["totalDiscount"].ToString());
                    string DateCheckOut = Convert.ToString(row["DateCheckOut"]);
                    string DateCheckIn = Convert.ToString(row["DateCheckIn"]);
                    
                    CultureInfo culture = new CultureInfo("vi-VN");

                    ds.result.Rows.Add(new object[] { total.ToString("c", culture),  totalFinal.ToString("c", culture), totalDiscount.ToString("c", culture), DateCheckIn.Substring(0, 9), DateCheckOut.Substring(0, 9) });
                }
            }
        }
        public void ShowReport()
        {
            rp.DataSource = ds;
            //invoiceReport.DataMember = invoiceDS.Invoice.;
            InsertData();

            ReportPrintTool ViewRP = new ReportPrintTool(rp);

            ViewRP.ShowPreview();
        }
    }
}
