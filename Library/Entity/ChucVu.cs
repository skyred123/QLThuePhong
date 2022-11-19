using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity
{
    public class ChucVu
    {
        [Key]
        public Guid MaCV { get; set; }
        public String? TenCV { get; set; }
    }
}
