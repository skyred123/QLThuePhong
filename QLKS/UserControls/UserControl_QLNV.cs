using Library.Entity;
using Library.Servser;
using Microsoft.EntityFrameworkCore;
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
    public partial class UserControl_QLNV : UserControl
    {
        Server server;
        public UserControl_QLNV()
        {
            server= new Server();
            InitializeComponent();
        }

        public void DSNV()
        {
            dgv_NhanVien.Rows.Clear();
            foreach(NhanVien nv in server.GetNhanVien())
            {
                dgv_NhanVien.Rows.Add(nv.MaNV,nv.TenNV,nv.SDT , nv.Email,nv.ChucVu.TenCV);
            }
            dgv_NhanVien.Refresh();
        }
        public void DefaulForenkey()
        {
            var a = server.GetNhanVien()[0];
            for (int i = 0; i < server.GetNhanVien().Count; i++)
            {
                server.GetNhanVien()[i].ChucVu = server.GetChucVu().FirstOrDefault(x => x.MaCV == server.GetNhanVien()[i].MaCV);
                //server.dbContext.SaveChanges();
            }
        }
        private void UserControl_QLNV_Load(object sender, EventArgs e)
        {
            DefaulForenkey();
            DSNV();
        }
    }
}
