using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class User
    {
        [Key]
        public Guid MaUser { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? MaNV { get; set; }
        [ForeignKey(name:("MaNV"))]
        public static NhanVien? NhanVien { get; set; }  
    }
}
