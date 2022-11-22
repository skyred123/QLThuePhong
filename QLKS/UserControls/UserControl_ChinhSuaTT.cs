using Library.Entity;
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
            label11.Text = "";
            if (UserView.nhanVien.Image == null)
            {
                image_Avatar.Image = Image.FromFile("D:\\Eleaning\\Công Nghệ Phần Mềm\\QLKS\\QLKS\\Image\\AvatarRong.jpg");
            }
            else
            {
                image_Avatar.Image = Image.FromStream(new MemoryStream(UserView.nhanVien.Image));
            }
            txt_Ten.Text = UserView.nhanVien.TenNV;
            txt_SDT.Text = UserView.nhanVien.SDT;
            txt_Email.Text = UserView.nhanVien.Email;
            txt_ChucVu.Text = server.GetChucVu().FirstOrDefault(p => p.MaCV == UserView.nhanVien.MaCV).TenCV;
        }

        private void btn_MK_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_DMK);
            label12.Text = "";
            txt_TenMK.Text = UserView.user.Name;
        }

        private void btn_LuuTTTK_Click(object sender, EventArgs e)
        {
            if (UserView.nhanVien.TenNV != txt_Ten.Text || UserView.nhanVien.SDT != txt_SDT.Text || UserView.nhanVien.Email != txt_Email.Text )
            {
                ImageConverter converter = new ImageConverter();
                UserView.nhanVien.Image = converter.ConvertTo(image_Avatar.Image, typeof(byte[])) as byte[];
                UserView.nhanVien.TenNV = txt_Ten.Text;
                UserView.nhanVien.Email = txt_Email.Text;
                UserView.nhanVien.SDT = txt_SDT.Text;
                if (UserView.nhanVien.Image.ToString() != null)
                {
                    server.UpdateNV(UserView.nhanVien);
                    label11.Text = "Lưu Thành Công";
                }
            }
        }
        private void btn_DoiAvatar_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    image_Avatar.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btn_LuuMK_Click(object sender, EventArgs e)
        {
            if(txt_MKC.Text !="" && txt_MKM1.Text != "" && txt_MKM2.Text != "" && txt_TenMK.Text != "")
            {
                if(txt_MKM1.Text == txt_MKM2.Text)
                {
                    if(UserView.user.Password == txt_MKC.Text)
                    {
                        UserView.user.Name = txt_TenMK.Text;
                        UserView.user.Password = txt_MKM2.Text;
                        server.UpdateUser(UserView.user);
                        label12.Text = "Lưu Thành Công";
                    }
                }
                label12.Text = "Nhập Sai Mật Khẩu";
            }
            else
                label12.Text = "Bạn Nhập Thiếu Thông Tin";
        }
    }
}
