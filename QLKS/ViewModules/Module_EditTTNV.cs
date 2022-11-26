using Library.Entity;
using Library.Servser;
using Microsoft.VisualBasic.ApplicationServices;
using QLKS.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;
using User = Library.Entity.User;

namespace QLKS.Modules
{
    public class Module_EditTTNV
    {
        Server server;
        public Module_EditTTNV()
        {
            server = new Server();
        }
        public void EditNV(NhanVien nhanVien)
        {
            if (nhanVien.MaNV.Count() != 10)
            {
                MessageBox.Show("Sai Số CCCD");
                return ;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(nhanVien.SDT, "[0-9]") == false && nhanVien.SDT.Count() != 10)
            {
                MessageBox.Show("Sai Số Điện Thoại");
                return;
            }
            foreach (NhanVien nv in server.GetNhanVien())
            {
                if (nv.MaNV == nhanVien.MaNV)
                {
                    MessageBox.Show("CCCD Đã Tồn Tại");
                    return ;
                }
            }
            if(nhanVien.MaCV == Guid.Empty)
            {
                MessageBox.Show("Tên Chức Vụ Không Tồn Tại");
                return ;
            }
            if (UserView.Edit == 2)
            {
                User user = new User();
                user.MaNV = nhanVien.MaNV;
                user.Name = nhanVien.TenNV;
                user.Password = "1";
                server.AddNhanVien(nhanVien);
                server.AddUser(user);
                MessageBox.Show("Lưu Thành Công Tài Khoản Có Mật Khẩu Là 1");
            }
            else
            {
                server.UpdateNV(nhanVien);
                MessageBox.Show("Lưu Thành Công");
            }
            return;
        }
    }
}
