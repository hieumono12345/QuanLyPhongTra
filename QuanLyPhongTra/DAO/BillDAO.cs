using QuanLyPhongTra.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTra.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        /// <summary>
        /// Thành công: bill ID
        /// thất bại: -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }

        public void CheckOut(int idBill, int discount, float totalPrice,string tableName)
        {            
            DataProvider.Instance.ExecuteNonQuery("EXEC dbo.USP_Payment @idBill , @discount , @totalPrice , @tableName", new object[] { idBill , discount , totalPrice , tableName });
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn , checkOut });
        }
        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn , checkOut , pageNum });
        }
        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn , checkOut });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        /// <summary>
        /// lấy kết quả cho báo cáo report
        /// </summary>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        /// <returns></returns>
        public DataTable GetResultForReportThongKe(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetResultReport @checkIn , @checkOut", new object[] { checkIn , checkOut });            
        }
        /// <summary>
        /// lấy data để vẽ biểu đồ
        /// </summary>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        /// <returns></returns>
        public DataTable GetDataForBieuDo(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetDataForBieuDo @checkIn , @checkOut", new object[] { checkIn , checkOut });
        }
        public List<Bill> GetStringDateBillById(int id)
        {
            List<Bill> list = new List<Bill>();

            string query = "select * from Bill where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                list.Add(bill);
            }

            return list;
            
        }


    }
}
