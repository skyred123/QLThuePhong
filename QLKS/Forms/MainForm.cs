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
    public partial class MainForm : Form
    {
        Server server;
        public MainForm()
        {
            server = new Server();
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panel_NhanVien.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (UserView.user.Name != "Admin")
            {
                UserView.nhanVien = server.GetNhanVien().Where(p => p.MaNV == UserView.user.MaNV).FirstOrDefault();
                UserView.chucVu = server.GetChucVu().Where(p => p.MaCV == UserView.nhanVien.MaCV).FirstOrDefault();
                if (UserView.chucVu.TenCV == "Quản Lý")
                {
                    btn_NhanVien.Text = "Quản Lý";
                }
                else if (UserView.chucVu.TenCV == "Nhân Viên")
                {
                    btn_QLNV.Visible = false;
                }
            }
            else
            {
                btn_TTNhanVien.Visible = false;
                btn_ChinhSuaTK.Visible = false;
            }
        }
        private void btn_NhanVien_Click(object sender, EventArgs e)
        {

            showSubMenu(panel_NhanVien);
        }

        private void btn_ChinhSuaTK_Click(object sender, EventArgs e)
        {
            UserControl_ChinhSuaTT _ChinhSuaTT = new UserControl_ChinhSuaTT(); ;
            panel_View.Controls.Add(_ChinhSuaTT);
            _ChinhSuaTT.Dock = DockStyle.Fill;
            _ChinhSuaTT.BringToFront();
        }

        private void btn_TTNhanVien_Click(object sender, EventArgs e)
        {
            UserControl_TTNhanVien _TTNhanVien = new UserControl_TTNhanVien(); ;
            panel_View.Controls.Add(_TTNhanVien);
            _TTNhanVien.Dock = DockStyle.Fill;
            _TTNhanVien.BringToFront();
        }
    }
}
