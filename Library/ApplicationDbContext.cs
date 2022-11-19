using Library.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> User { get; set; }
        public DbSet<NhanVien> nhanVien { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public ApplicationDbContext()
            : base(getApplicationDbContext())
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public static DbContextOptions<ApplicationDbContext> getApplicationDbContext()
        {
            String con= @"Server=DESKTOP-K5EGHTF\SQLEXPRESS;Database=QLTP;User Id=sa;Password=sa;";
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(con).Options;
            return contextOptions;
        }
    }
}
