using QuanLyPhongTra.DAO;
using QuanLyPhongTra.DTO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if (Login(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fTabManager f = new fTabManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("sai tên tài khoản hoặc mật khẩu!");
            }
        }

        bool Login(string userName,string passWorld)
        {
            return AccountDAO.Instance.Login(userName, passWorld);
            //return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("bạn có muốn thoát chương trình?", "thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        
    }
}
