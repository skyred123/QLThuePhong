using Library.Servser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.UserControls
{
    public partial class UserControl_ChinhSuaTT : UserControl
    {
        Server server;
        public UserControl_ChinhSuaTT()
        {
            server = new Server();
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panel_DTTTK.Visible = false;
            panel_DMK.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void UserControl_ChinhSuaTT_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_TTTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_DTTTK);
            txt_Ten.Text = UserView.nhanVien.TenNV;
            txt_SDT.Text = UserView.nhanVien.SDT;
            txt_Email.Text = UserView.nhanVien.Email;
            txt_ChucVu.Text = server.GetChucVu().FirstOrDefault(p => p.MaCV == UserView.nhanVien.MaCV).TenCV;
        }

        private void btn_MK_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_DMK);
        }
    }
}
