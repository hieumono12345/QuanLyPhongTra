using DevExpress.XtraReports.UI;
using QuanLyPhongTra.DAO;
using QuanLyPhongTra.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTra
{
    public partial class fTabManager : Form
    {
        
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fTabManager(Account acc)
        {
            
            InitializeComponent();
            this.loginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbToTable);
            LoadComboboxTable(cbFromTable);
            ChangeAccount(acc.Type);
        }

        #region Method
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem1.Enabled = type == 1;
            //thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                //btn.Image = Image.FromFile(@"C:\Users\tung2\Downloads\icons8-coffee-table-64.png");
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                /*
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        btn.Image = Image.FromFile(@"C:\Users\tung2\Desktop\ThucChien\anh\icons8-table-50.png");
                        break;
                    default:
                        btn.BackColor = Color.AntiqueWhite;
                        btn.Image = Image.FromFile(@"C:\Users\tung2\Desktop\ThucChien\anh\icons8-table-50 (1).png");
                        break;
                }*/

                flpTable.Controls.Add(btn);
            }
        }

        void LoadTotalFinalPrice(int idTable)
        {
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(idTable);
            int discount = (int)nmDisCount.Value;
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(idTable);
            float totalPrice = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                if (item.Count > 0)
                {
                    totalPrice += item.TotalPrice;
                }
            }
            float finalTotalPrice = totalPrice - totalPrice / 100 * discount;                        
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = finalTotalPrice.ToString("c", culture);
        }
        void ShowBill(int id,string nameTable)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            lbTenban.Text= nameTable;
            float totalPrice = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                if (item.Count > 0)
                {
                    ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                    lsvItem.SubItems.Add(item.Count.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());
                    totalPrice += item.TotalPrice;
                    lsvBill.Items.Add(lsvItem);
                }
                
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c", culture);

        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion

        #region Events

        void btn_Click(object sender, EventArgs e)//là mỗi khi click vào btn table nào thì sẽ 
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            string TableName = ((sender as Button).Tag as Table).Name;
            LoadTotalFinalPrice(tableID);
            lsvBill.Tag= (sender as Button).Tag;
            ShowBill(tableID, TableName);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void thôngTinĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccoutProfile fAccoutProfile = new fAccoutProfile(loginAccount);
            this.Hide();
            fAccoutProfile.UpdateAccount += f_UpdateAccount;
            fAccoutProfile.ShowDialog();
            this.Show();
        }
        void f_UpdateAccount (object sender, AccountEvent e)
        {
            thôngThiTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản của (" + e.Acc.DisplayName; 
        }
        private void adminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            Hide();
            fAdmin.loginAccount = loginAccount;
            fAdmin.ShowDialog();
            LoadTable();
            this.Show();            
        }        
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            
            LoadFoodListByCategoryID(id);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lsvBill.Tag as Table;
                if (table.Status == "Có người" || table.Status == "Trống")
                {
                    LoadTotalFinalPrice(table.ID);

                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int foodID = (cbFood.SelectedItem as Food).ID;
                    int count = (int)mnFoodCount.Value;

                    if (idBill == -1)
                    {
                        BillDAO.Instance.InsertBill(table.ID);
                        BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                    }
                    else
                    {
                        BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                    }
                    ShowBill(table.ID, table.Name);
                    if (table.Status == "Trống")
                    {
                        LoadTable();
                    }                    
                }
                else MessageBox.Show("Bàn đang đang được gộp xin vui lòng thêm món ở bàn được gộp!");
            }catch(Exception ex) { }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                
                Table table = lsvBill.Tag as Table;
                if (table.Status == "Có người")
                {
                    LoadTotalFinalPrice(table.ID);
                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int discount = (int)nmDisCount.Value;
                    List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(table.ID);
                    float totalPrice = 0;
                    foreach (DTO.Menu item in listBillInfo)
                    {
                        if (item.Count > 0)
                        {
                            totalPrice += item.TotalPrice;
                        }
                    }
                    float finalTotalPrice = totalPrice - totalPrice / 100 * discount;
                    //MessageBox.Show("idBIll:" + idBill+"-"+table.Name+"-"+ finalTotalPrice+"-"+ discount);
                    LoadTable();

                    if (idBill != -1)
                    {
                        if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            //MessageBox.Show("idBIll:" + idBill + "-" + table.Name + "-" + finalTotalPrice + "-" + discount);

                            BillDAO.Instance.CheckOut(idBill, discount, finalTotalPrice, table.Name);
                            FoodDAO.Instance.makeFoodReport(idBill);
                            LoadTable();
                            ShowBill(table.ID, table.Name);

                            List<Bill> list = new List<Bill>();
                            list = BillDAO.Instance.GetStringDateBillById(idBill);
                            Bill bill = list.First();
                            string Date = "HaNoi " + bill.DateCheckIn.ToString();
                            fHoaDon f = new fHoaDon(totalPrice, totalPrice / 100 * discount, finalTotalPrice, Date, table.Name, idBill);
                            f.ShowDialog();
                            //f.ShowDialog();
                            this.Show();
                        }
                    }
                }
                else { MessageBox.Show("Không thể thanh toán cho bàn trống hoặc đã đang được gộp! "); }

            }
            catch { }
            LoadTable();
        }
        private void btnSwichTable_Click(object sender, EventArgs e)
        {
            try
            {
                
                string strSratus1 = (cbToTable.SelectedItem as Table).Status;


                int id1 = (cbToTable.SelectedItem as Table).ID;
                int id2 = (cbFromTable.SelectedItem as Table).ID;

                if (strSratus1 == "Trống")
                {
                    MessageBox.Show("Không được chuyển bàn " + strSratus1 + " đến bàn khác!");

                }
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {1} qua bàn {0}", (cbFromTable.SelectedItem as Table).Name, (cbToTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        TableDAO.Instance.SwitchTable(id1, id2);
                        ShowBill(id2, (lsvBill.Tag as Table).Name);
                        LoadTable();
                    }
                }
            }
            catch { }
        
        }
        private void btnPoolTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id1 = (lsvBill.Tag as Table).ID;

                int id2 = (cbFromTable.SelectedItem as Table).ID;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn gộp bill {1} qua bàn {0}", (lsvBill.Tag as Table).Name, (cbFromTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TableDAO.Instance.PoolTable(id2, id1);
                    ShowBill(id1, (lsvBill.Tag as Table).Name);
                    LoadTable();
                }
            }catch(Exception ex) { }
        }
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDisCount.Value;
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(table.ID);
            float totalPrice = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                if (item.Count > 0)
                {
                    totalPrice += item.TotalPrice;
                }
            }

            float finalTotalPrice = totalPrice - totalPrice / 100 * discount;
            if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho bàn ban đầu là:" + totalPrice + " sau khi giam la " + finalTotalPrice + " của" + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CultureInfo culture = new CultureInfo("vi-VN");

                //Thread.CurrentThread.CurrentCulture = culture;

                txbTotalPrice.Text = finalTotalPrice.ToString("c", culture);
            }

        }

        #endregion
        private void táchBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSeparate SeparateTable = new fSeparate();
            //this.Hide();
            SeparateTable.ShowDialog();
            this.Show();
            LoadTable();
        }

        private void btnCombineTable_Click(object sender, EventArgs e)
        {
            int id1 = (cbToTable.SelectedItem as Table).ID;
            int id2 = (cbFromTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn gộp bàn {0} qua bàn {1}",(cbToTable.SelectedItem as Table).Name, (cbFromTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.CombineTable(id1, id2);
                ShowBill(id1, (lsvBill.Tag as Table).Name);
                LoadTable();
            }
        }

      
    }
}
