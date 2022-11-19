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

namespace QLKS
{
    public partial class MainForm : Form
    {
        Server server;
        UserControl_ChinhSuaTT _ChinhSuaTT ;
        UserControl_TTNhanVien _TTNhanVien ;
        public MainForm()
        {
            server = new Server();
            _ChinhSuaTT = new UserControl_ChinhSuaTT();
            _TTNhanVien = new UserControl_TTNhanVien();
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
            UserView.nhanVien = server.GetNhanVien().Where(p => p.MaNV == UserView.user.MaNV).FirstOrDefault();
            if (UserView.user.Name == "Admin")
            {
                image_Avatar.Image = Image.FromFile("D:\\Eleaning\\Công Nghệ Phần Mềm\\QLKS\\QLKS\\Image\\Avatar.jfif");
                btn_NhanVien.Visible=false;
            }
            else if(UserView.user.Name == "NhanVien")
            {

            }
        }
        private void btn_NhanVien_Click(object sender, EventArgs e)
        {

            showSubMenu(panel_NhanVien);
        }

        private void btn_ChinhSuaTK_Click(object sender, EventArgs e)
        {
            panel_View.Controls.Add(_ChinhSuaTT);
            _ChinhSuaTT.Dock = DockStyle.Fill;
            _ChinhSuaTT.BringToFront();
        }

        private void btn_TTNhanVien_Click(object sender, EventArgs e)
        {
            panel_View.Controls.Add(_TTNhanVien);
            _TTNhanVien.Dock = DockStyle.Fill;
            _TTNhanVien.BringToFront();
        }
    }
}
