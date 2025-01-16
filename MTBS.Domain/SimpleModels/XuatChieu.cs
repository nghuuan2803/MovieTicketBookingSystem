using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class XuatChieu
    {
        [Key]
        public int Id { get; set; }
        public DateTime GioChieu { get; set; }
        public DateTime? GioKetThuc { get; set; }
        public int ThoiLuong { get; set; }

        public int PhimId { get; set; }
        [JsonIgnore]
        public Phim? Phim { get; set; }

        public int PhongChieuId { get; set; }
        [JsonIgnore]
        public PhongChieu? PhongChieu { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Ve>? DsVe { get; set; }

        //---------------------------------------------//

        public XuatChieu() { }
        public XuatChieu(DateTime gioChieu,int thoiLuong)
        {
            GioChieu = gioChieu;
            ThoiLuong = thoiLuong;
            GioKetThuc = GioChieu.AddMinutes(thoiLuong);
        }

        public void SetGioKetThuc()
        {
            GioKetThuc = GioChieu.AddMinutes(ThoiLuong);
        }
    }
}
