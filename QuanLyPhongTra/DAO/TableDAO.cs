using QuanLyPhongTra.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyPhongTra.DAO
{
    public class TableDAO

    {
        public static int TableWidth = 185;
        public static int TableHeight = 185;
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) { instance = new TableDAO(); } return TableDAO.instance; }
            private set { instance = value; }
        }
        public TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<DTO.Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)//kieu du lieu dataRow là mỗi dòng của cái Table lấy được từ câu lệnh mà trong
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }
        public void SwitchTable(int id1,int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwichTable @idtable1 , @idTable2 ", new object[] { id1, id2 });
        }
        public void PoolTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_PoolTable @idTable1 , @idTable2 ", new object[] { id1, id2 });
        }
        public void CombineTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_CombineTable @idTable1 , @idTable2 ", new object[] { id1, id2 });
        }
        public void SeparateTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("", new object[] {id1, id2});
        }
        public bool DeleteTable(int id)
        {
            string query = "USP_DeleteTable @idTable";
            int i = DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
            return i > 0;
        }
        public bool AddTable(string tableName)
        {
            string query = "USP_AddTable @tableName";
            int i = DataProvider.Instance.ExecuteNonQuery(query,new object[]{ tableName});
            return i > 0;
        }
        public bool EditTable(string tableName, string status, int idTable)
        {
            string query = "USP_EditTable @tableName , @statusTable , @idTable";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { tableName ,status ,idTable});
            return result > 0;
        }
        

    }
}
