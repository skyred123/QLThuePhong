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
            /*if (nhanVien.TenNV != txt_Ten.Text || nhanVien.SDT != txt_SDT.Text || nhanVien.Email != txt_Email.Text )
            {*/
                ImageConverter converter = new ImageConverter();
                nhanVien.Image = converter.ConvertTo(image_Avatar.Image, typeof(byte[])) as byte[];
                nhanVien.TenNV = txt_Ten.Text;
                nhanVien.Email = txt_Email.Text;
                int c = txt_SDT.Text.Count();
                if (System.Text.RegularExpressions.Regex.IsMatch(txt_SDT.Text, "[0-9]") == true && txt_SDT.Text.Count() == 10)
                {
                    nhanVien.SDT = txt_SDT.Text;
                    if (nhanVien.Image.ToString() != null)
                    {
                        if (UserView.Edit == 2)
                        {
                            foreach(NhanVien nv in server.GetNhanVien())
                            {
                                if(nv.MaNV == txt_CCCD.Text)
                                {
                                    label11.Text = "CCCD Đã Tồn Tại";
                                    Clear();
                                    return;
                                }
                                else
                                {
                                }
                            }
                            foreach(ChucVu cv in server.GetChucVu())
                            {
                                if (string.Compare(cv.TenCV, txt_ChucVu.Text, true) != 0)
                                {
                                    label11.Text = "Tên Chức Vụ Không Tồn Tại";
                                    Clear();
                                    return;
                                }
                            }
                            nhanVien.MaNV = txt_CCCD.Text;
                            nhanVien.MaCV = server.GetChucVu().FirstOrDefault(x => string.Compare(x.TenCV,txt_ChucVu.Text,true)==0).MaCV;
                            user.MaNV = nhanVien.MaNV;
                            user.Name = nhanVien.TenNV;
                            user.Password = "1";
                            server.AddNhanVien(nhanVien);
                            server.AddUser(user);
                            label11.Text = "Lưu Thành Công Tài Khoản Có Mật Khẩu Là 1";
                        }
                        else
                        {
                            server.UpdateNV(nhanVien);
                            label11.Text = "Lưu Thành Công";
                        }
                    }
                }
                else
                {
                    label11.Text = "Sai Số Điện Thoại";
                }
            //}//
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
