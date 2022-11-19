using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entity;

namespace Library.Servser
{
    public class Server
    {
        ApplicationDbContext dbContext;
        public Server() { 
            dbContext= new ApplicationDbContext();
        }
        public List<User> GetUser()
        {
            return dbContext.User.ToList();
        }
        public List<NhanVien> GetNhanVien() 
        {
            return dbContext.nhanVien.ToList();
        }
        public List<ChucVu> GetChucVu()
        {
            return dbContext.ChucVu.ToList();
        }
        public void UpdateNV(NhanVien nv)
        {
            var nhanvien = dbContext.nhanVien.Where(p=> p.MaNV == nv.MaNV).FirstOrDefault();
            nhanvien.TenNV = nv.TenNV;
            nhanvien.SDT = nv.SDT;
            nhanvien.Email = nv.Email;
            nhanvien.MaCV = nv.MaCV;
            nhanvien.Image = nv.Image;
            dbContext.nhanVien.Update(nhanvien);
            dbContext.SaveChanges();
        }
    }
}
