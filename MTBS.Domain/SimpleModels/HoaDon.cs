using MTBS.Domain.SimpleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }
        public double ThanhTien { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int KhachHangId { get; set; }
        [JsonIgnore]
        public KhachHang? KhachHang { get; set; }

        public int XuatChieuId { get; set; }
        [JsonIgnore]
        public XuatChieu? XuatChieu { get; set; }

        [JsonIgnore]
        public virtual ICollection<ChiTietHD>? DsVe { get; set; }
    }
}
