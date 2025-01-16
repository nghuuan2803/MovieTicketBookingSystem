using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{
    public class XuatChieuRequest
    {
        public DateTime GioChieu { get; set; }
        public int ThoiLuong { get; set; }
        public int PhimId { get; set; }
        public int PhongChieuId { get; set; }
    }
}
