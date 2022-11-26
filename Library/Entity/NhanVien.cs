using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class NhanVien
    {
        [Key]
        public string? MaNV { get; set; }
        public string? TenNV { get; set; }
        public string? SDT { get; set; }
        public byte[]? Image { get; set; }
        public string? Email { get; set; }
        [ForeignKey(name: "ChucVu")]
        public Guid MaCV { get; set; }
        
        public virtual ChucVu ChucVu { get; set; }
    }
}
