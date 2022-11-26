using Library.Entity;
using Library.Servser;
using QLKS.Modules;
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
        NhanVien nhanVien;
        User user;
        public UserControl_ChinhSuaTT()
        {
            server = new Server();
            nhanVien= new NhanVien();
            user= new User();
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
        private void Clear()
        {
            image_Avatar.Image = null;
            txt_CCCD.Text = "";
            txt_Ten.Text = "";
            txt_SDT.Text = "";
            txt_ChucVu.Text = "";
            txt_Email.Text = "";
            txt_TenMK.Text = "";
            txt_MKC.Text = "";
            txt_MKM1.Text = "";
            txt_MKM2.Text = "";
        }
        private void UserControl_ChinhSuaTT_Load(object sender, EventArgs e)
        {
            if(UserView.Edit == 0)
            {
                nhanVien = UserView.nhanVien;
                user = UserView.user;
                label13.Visible= false;
                txt_CCCD.Visible=false;
            }
            else if(UserView.Edit == 1)
            {
                nhanVien = UserView.nhanVienEdit;
                user = UserView.userEdit;
                label13.Visible = false;
                txt_CCCD.Visible = false;
            }
            else if(UserView.Edit == 2)
            {
                nhanVien = new NhanVien();
                user = new User();
                panel_MK.Visible= false;
            }
        }
        private void btn_TTTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_DTTTK);
            label11.Text = "";
            if (nhanVien.MaNV != null && user.MaUser != null){
                if (nhanVien.Image == null)
                {
                    image_Avatar.Image = Image.FromFile("D:\\Eleaning\\Công Nghệ Phần Mềm\\QLKS\\QLKS\\Image\\AvatarRong.jpg");
                }
                else
                {
                    image_Avatar.Image = Image.FromStream(new MemoryStream(nhanVien.Image));
                }
                txt_Ten.Text = nhanVien.TenNV;
                txt_SDT.Text = nhanVien.SDT;
                txt_Email.Text = nhanVien.Email;
                txt_ChucVu.Text = server.GetChucVu().FirstOrDefault(p => p.MaCV == nhanVien.MaCV).TenCV;
            }
            else
            {

            }
        }

        private void btn_MK_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_DMK);
            label12.Text = "";
            if (nhanVien.MaNV != null && user.MaUser != null)
            {
                txt_TenMK.Text = user.Name;
            }
            else
            {

            }
        }

        private void btn_LuuTTTK_Click(object sender, EventArgs e)
        {
            ImageConverter converter = new ImageConverter();
            nhanVien.MaNV = txt_CCCD.Text;
            nhanVien.TenNV = txt_Ten.Text;
            nhanVien.Email = txt_Email.Text;
            nhanVien.SDT = txt_SDT.Text;
            nhanVien.MaCV = Guid.Empty;
            if (image_Avatar.Image == null)
            {
                nhanVien.Image = (byte[])converter.ConvertTo(Image.FromFile("D:\\Eleaning\\Code\\QLKS\\QLKS\\Image\\AvatarRong.jpg"), typeof(byte[]));
            }
            else
            {
                nhanVien.Image = (byte[])converter.ConvertTo(image_Avatar.Image, typeof(byte[]));
            }
            foreach (ChucVu cv in server.GetChucVu())
            {
                if (string.Compare(cv.TenCV, txt_ChucVu.Text, true) == 0)
                {
                    nhanVien.MaCV = server.GetChucVu().FirstOrDefault(x => string.Compare(x.TenCV, txt_ChucVu.Text, true) == 0).MaCV;
                }
            }
            Module_EditTTNV module_EditTTNV = new Module_EditTTNV();
            module_EditTTNV.EditNV(nhanVien);
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
                    if (System.Text.RegularExpressions.Regex.IsMatch(txt_SDT.Text, "^[a-zA-Z0-9\x20]+$"))
                    {
                        if (user.Password == txt_MKC.Text)
                        {
                            user.Name = txt_TenMK.Text;
                            user.Password = txt_MKM2.Text;
                            server.UpdateUser(user);
                            label12.Text = "Lưu Thành Công";
                        }
                    }
                    else
                        label12.Text = "Mật Khẩu Chứa Ký Tự Đặt Biệt";
                }
                else
                    label12.Text = "Nhập Sai Mật Khẩu";
            }
            else
                label12.Text = "Bạn Nhập Thiếu Thông Tin";
        }
    }
}
