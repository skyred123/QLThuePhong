using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class ChucVu
    {
        public ChucVu() {
            NhanViens = new HashSet<NhanVien>();
        }
        [Key]
        public Guid MaCV { get; set; }
        public String? TenCV { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
