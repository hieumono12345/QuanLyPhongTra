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
    public partial class fSeparate : Form
    {
        public fSeparate()
        {
            InitializeComponent();
            LoadComboboxTable(cbTableFirst);
            LoadComboboxTable(cbTabeTabeSecond);
            LoadCategory();
        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        void addFood(int idTable,int idFood, int count)
        {
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(idTable);
            
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(idTable);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }

            
            
        }

        private void btnComfird_Click(object sender, EventArgs e)
        {
            try {
                string status1 = (cbTableFirst.SelectedItem as Table).Status;
                string status2 = (cbTabeTabeSecond.SelectedItem as Table).Status;
                if ( status2=="Trống" || status2=="Có Người")
                {
                    int idTableFirst = (cbTableFirst.SelectedItem as Table).ID;
                    int idtablSecond = (cbTabeTabeSecond.SelectedItem as Table).ID;
                    int foodID = (cbFood.SelectedItem as Food).ID;
                    int count = (int)mnFoodCount.Value;
                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(idTableFirst);

                    if (FoodDAO.Instance.CheckFoodInBillInfo(foodID, idBill))
                    {
                        addFood(idTableFirst, foodID, -count);
                        addFood(idtablSecond, foodID, count);
                        MessageBox.Show("Tách món thành công");
                    }
                    else
                    {
                        MessageBox.Show("Món không tồn tại trong bill");
                    }
                    string status = (cbTableFirst.SelectedItem as Table).Status;
                    ShowBill(idTableFirst, status);
                }
                else
                {
                    MessageBox.Show("Không được tách đến bàn đang gộp! ");
                }
            }catch (Exception ex) { }
        }

        private void SelectedIndexChangedcbTableFirst(object sender, EventArgs e)
        {
            int id = (cbTableFirst.SelectedItem as Table).ID;
            string status = (cbTableFirst.SelectedItem as Table).Status;
            ShowBill(id, status);
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }
        void ShowBill(int id, string status)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            foreach (DTO.Menu item in listBillInfo)
            {
                if (item.Count > 0)
                {
                    ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                    lsvItem.SubItems.Add(item.Count.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());
                    lsvBill.Items.Add(lsvItem);
                }

            } 
            txbStatus.Text = status;    
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
    }
}
