using Library.Entity;
using Library.Servser;
using Microsoft.EntityFrameworkCore;
using QLKS.Forms;
using QLKS.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
                dgv_NhanVien.Rows.Add(nv.MaNV, nv.TenNV, Image.FromStream(new MemoryStream(nv.Image)), nv.SDT, nv.Email, nv.ChucVu.TenCV);
            }
            dgv_NhanVien.Refresh();
        }
        public void DefaulForenkey()
        {
            for (int i = 0; i < server.GetNhanVien().Count; i++)
            {
                server.GetNhanVien()[i].ChucVu = server.GetChucVu().FirstOrDefault(x => x.MaCV == server.GetNhanVien()[i].MaCV);
            }
        }
        private void UserControl_QLNV_Load(object sender, EventArgs e)
        {
            DefaulForenkey();
            DSNV();
        }

        private void dgv_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_NhanVien.Columns[e.ColumnIndex].ToolTipText == "Edit")
            {
                EditForm editForm = new EditForm();
                UserView.Edit = editForm.EditNV;
                UserView.nhanVienEdit = server.GetNhanVien().FirstOrDefault(x=> x.MaNV == dgv_NhanVien.Rows[e.RowIndex].Cells[0].Value.ToString());
                UserView.userEdit = server.GetUser().FirstOrDefault(x=>x.MaNV == UserView.nhanVienEdit.MaNV);
                editForm.ShowDialog();
                
            }
            else if(dgv_NhanVien.Columns[e.ColumnIndex].ToolTipText == "Delete")
            {
                if (MessageBox.Show("Thông Báo","Bạn Muốn Xóa",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    UserView.nhanVienDelete = server.GetNhanVien().FirstOrDefault(x => x.MaNV == dgv_NhanVien.Rows[e.RowIndex].Cells[0].Value.ToString());
                    UserView.userDelete = server.GetUser().FirstOrDefault(x => x.MaNV == UserView.nhanVienDelete.MaNV);
                    server.DeleteUser(UserView.userDelete);
                    server.DeleteNV(UserView.nhanVienDelete);
                    MessageBox.Show("Xóa Thành Công");
                }
            }
            DSNV();
        }

        private void btn_TaoNV_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm();
            UserView.Edit = editForm.CreateNV;
            editForm.ShowDialog();
            DSNV(); 
        }
    }
}
