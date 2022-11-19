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
    }
}
