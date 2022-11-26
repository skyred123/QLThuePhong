using Library.Entity;
using Library.Servser;
using QLKS.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Forms
{
    public partial class LoginForm : Form
    {
        Server server;

        public LoginForm()
        {
            server = new Server();
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                int check = 0;
                if (System.Text.RegularExpressions.Regex.IsMatch(txt_MatKhau.Text, "^[a-zA-Z0-9\x20]+$") == false)
                {
                    MessageBox.Show("Mật Khẩu Chứa Ký Tự Đặt Biệt");
                    check = 1;
                }
                foreach (User item in server.GetUser())
                {
                    if (item.Name == txt_Ten.Text && item.Password == txt_MatKhau.Text)
                    {
                        UserView.user = item;
                        MainForm form = new MainForm();
                        this.Hide();
                        form.Show();
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    MessageBox.Show("Sai Tên Hoặc Mật Khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txt_Ten.Text = "Thang";
            txt_MatKhau.Text = "Thang";
        }
    }
}
