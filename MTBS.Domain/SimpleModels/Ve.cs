using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class Ve
    {
        [Key]
        public int Id { get; set; }
        public int TrangThai { get; set; } //0:open, 1: lock, 2: sold
        public double Gia { get; set; }
        public string? NguoiGiu { get; set; }
        public DateTime? CapNhatLuc { get; set; }

        public int XuatChieuId { get; set; }
        [JsonIgnore]
        public XuatChieu? XuatChieu { get; set; }

        public int GheId { get; set; }
        //[JsonIgnore]
        public Ghe? Ghe { get; set; }
    }
}
