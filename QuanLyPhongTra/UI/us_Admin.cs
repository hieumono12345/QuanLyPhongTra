using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTra.DAO;

namespace QuanLyPhongTra.UI
{
    public partial class us_Admin : UserControl
    {
        public us_Admin()
        {
            InitializeComponent();
        }

        public void us_Admin_Load(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = FoodDAO.Instance.getTest();
        }
    }
}
