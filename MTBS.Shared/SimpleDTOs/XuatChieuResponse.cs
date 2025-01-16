using MTBS.Domain.SampleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{
    public class XuatChieuResponse
    {
        public int XuatChieuId { get; set; }
        public int PhongChieuId { get; set; }
        public string TenPhong { get; set; }
        public int PhimId { get; set; }
        public string TenPhim { get; set; }
        public DateTime GioChieu { get; set; }
        public DateTime GioKetThuc { get; set; }
        //public SoDoVe SoDoGhe { get; set; }
        public string Layout { get; set; }
        public Metadata Metadata { get; set; }
        public IEnumerable<Ve> DsVe { get; set; }
    } 
}
