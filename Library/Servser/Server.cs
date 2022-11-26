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
        public ApplicationDbContext dbContext;
        public Server() { 
            dbContext= new ApplicationDbContext();
        }
        public List<ChucVu> GetChucVu()
        {
            return dbContext.ChucVu.ToList();
        }
        public List<NhanVien> GetNhanVien()
        {
            return dbContext.NhanVien.ToList();
        }
        public List<User> GetUser()
        {
            return dbContext.User.ToList();
        }
        
        
        public void UpdateNV(NhanVien nv)
        {
            var nhanvien = dbContext.NhanVien.Where(p=> p.MaNV == nv.MaNV).FirstOrDefault();
            nhanvien.TenNV = nv.TenNV;
            nhanvien.SDT = nv.SDT;
            nhanvien.Email = nv.Email;
            nhanvien.MaCV = nv.MaCV;
            nhanvien.Image = nv.Image;
            dbContext.NhanVien.Update(nhanvien);
            dbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var item = dbContext.User.FirstOrDefault(p => p.MaUser == user.MaUser);
            item.Name = user.Name;
            item.Password= user.Password;
            dbContext.User.Update(item);
            dbContext.SaveChanges();
        }
        public void AddNhanVien(NhanVien nv)
        {
            dbContext.NhanVien.Add(nv);
            dbContext.SaveChanges();
        }
    }
}
