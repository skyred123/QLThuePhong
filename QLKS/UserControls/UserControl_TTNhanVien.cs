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
    public partial class UserControl_TTNhanVien : UserControl
    {
        Server server;
        public UserControl_TTNhanVien()
        {
            server = new Server();
            InitializeComponent();
        }

        private void UserControl_TTNhanVien_Load(object sender, EventArgs e)
        {
            txt_MaNV.Text = UserView.nhanVien.MaNV;
            image_Avatar.Image = Image.FromStream(new MemoryStream(UserView.nhanVien.Image));
            txt_Ten.Text = UserView.nhanVien.TenNV;
            txt_SDT.Text = UserView.nhanVien.SDT;
            txt_Email.Text = UserView.nhanVien.Email;
            txt_CV.Text = server.GetChucVu().FirstOrDefault(p => p.MaCV == UserView.nhanVien.MaCV).TenCV;
        }
    }
}
