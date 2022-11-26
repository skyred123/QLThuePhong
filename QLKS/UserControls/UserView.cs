using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.UserControls
{
    public class UserView
    {
        public static User? user { get; set; }
        public static NhanVien? nhanVien { get; set; }
        public static ChucVu? chucVu { get; set; }
        public static int Edit { get; set; }
        public static NhanVien? nhanVienEdit { get; set; }
        public static User? userEdit { get; set; }
        public static NhanVien? nhanVienDelete { get; set; }
        public static User? userDelete { get; set; }
    }
}
