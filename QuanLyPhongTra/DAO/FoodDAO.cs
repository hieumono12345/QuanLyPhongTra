using QuanLyPhongTra.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyPhongTra.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertFood(string name, int id, float price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_InsertFood @name , @idCategory , @price", new object[] { name, id, price });

            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateFood @name , @idCategory , @price , @id", new object[] { name, id, price,idFood });

            return result > 0;
        }
        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool CheckFoodInBillInfo(int idFood, int idBill)
        {
            string query = string.Format("dbo_USPCheckFoodInBillInf @idFood , @idBill");
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {idFood, idBill});
            return result.Rows.Count > 0;
        }
        public DataTable GetFoodList(int idBill)
        {
            string query = "USP_GetListFoodByBill @idBill";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object [] { idBill});
            return result;
        }
        public List<BillCheckOut> GetListFoodInBill(int idBill)
        {
            List<BillCheckOut> result = new List<BillCheckOut>();
            string query = "USP_GetListFoodByBill2 @idBill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
            foreach (DataRow item in data.Rows)
            {
                BillCheckOut food = new BillCheckOut(item);
                result.Add(food);
            }
            return result;
        }
        public DataTable getTest()
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("select * from billinfo.dto");
            return result;
        }
        public void makeFoodReport(int idBIll)
        {
            string query = "EXEC dbo.USP_Report @idBill";
            DataProvider.Instance.ExecuteQuery(query, new object[] { idBIll });
        }
        public DataTable getFoodAndCount(DateTime checkIn, DateTime checkOut)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(@"SELECT dbo.Food.name, SUM(count) AS count FROM dbo.BillInfo , dbo.Food  WHERE dbo.BillInfo.idFood= dbo.Food.id GROUP BY dbo.Food.name");
            return result;
        }

    }
}
