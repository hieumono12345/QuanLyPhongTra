using DevExpress.XtraReports;
using QuanLyPhongTra.DAO;
using QuanLyPhongTra.DTO;
using QuanLyPhongTra.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTra
{
    public partial class fAdmin : Form
    {
        public Account loginAccount;
        BindingSource foodList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountList = new BindingSource();
        ThongKeRP_Provider thongKeRP_Provider;
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        #region menthod
        void Load()
        {
            dtgvFood.DataSource = foodList;
            dtgvTableFood.DataSource = tableList;
            dtgvAccount.DataSource= accountList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListFood();
            LoadCategoryIntoCombobox(cbFoodCategory);
            AddFoodBinding();
            LoadTableFood();
            AddTableBinding();
            LoadStatusTable(cbStatusTable);
            AddAccouBinding();
            LoadAccount();
        }
        #region DoanhThu Menthod
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        #endregion

        #region ThucAn Menthod
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        
        #endregion

        #region bàn ăn menthod
        void LoadStatusTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Status";
        }
        void LoadTableFood()
        {
            dtgvTableFood.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddTableBinding()
        {
            txbIDTable.DataBindings.Add("Text", dtgvTableFood.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTableName.DataBindings.Add("Text", dtgvTableFood.DataSource, "Name", true, DataSourceUpdateMode.Never);
            cbStatusTable.DataBindings.Add("Text", dtgvTableFood.DataSource, "status", true, DataSourceUpdateMode.Never);
            
        }
        #endregion

        

        #endregion



        #region events

        #region events_doanh Thu
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        #region events_thức ăn
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch 
            {
                MessageBox.Show("Không tìm thấy thức ăn");
            }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
        }
        private void btnAlter_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }
        private void btnSeachFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        #endregion

        #region even bàn ăn
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadTableFood();
        }
        private void bntAddTable_Click(object sender, EventArgs e)
        {
            string idtable = txbIDTable.Text;
            string nametable = txbTableName.Text;
            string statustable = cbStatusTable.Text;
            if (TableDAO.Instance.AddTable(nametable))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadTableFood();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm bàn lỗi!");
            }

        }
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIDTable.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công!");
                LoadTableFood();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa bàn lỗi!");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int idtable = Convert.ToInt32(txbIDTable.Text);
            string nametable = txbTableName.Text;
            string statustable = cbStatusTable.Text;
            if (TableDAO.Instance.EditTable(nametable, statustable, idtable))
            {
                MessageBox.Show("Thay đổi thông tin bàn thành công!");
                LoadTableFood();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa bàn lỗi!");
            }
        }
        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }







        #endregion



        #endregion


        #region account Menthod
        void AddAccouBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        #endregion

        #region account Menthod
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmTypeAccount.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmTypeAccount.Value;
            EditAccount(userName, displayName, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPass(userName);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }


        #endregion

       /* private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }   
               
        private void btnFirst_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            txbPageBill.Text = lastPage.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int i = DataProvider.Instance.ExecuteNonQuery("select count(*) from bill");
            MessageBox.Show("" + i);
            int page = Convert.ToInt32(txbPageBill.Text);

            if (page > 1)
                page--;

            txbPageBill.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < sumRecord)
                page++;

            txbPageBill.Text = page.ToString();
        }*/

        private void btnReport_Click(object sender, EventArgs e)
        {
            DateTime dateFirst = dtpkFromDate.Value;
            DateTime dateSecond = dtpkToDate.Value;

            if (thongKeRP_Provider == null)
            {
                thongKeRP_Provider = new Report.ThongKeRP_Provider(dateFirst, dateSecond);
            }
            thongKeRP_Provider.ShowReport();
        }

        private void btnBieuDôCt_Click(object sender, EventArgs e)
        {
            fthongKe fbieudo = new fthongKe(dtpkFromDate.Value, dtpkToDate.Value);
            this.Hide();
            fbieudo.ShowDialog();
        }

        private void tpTable_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
