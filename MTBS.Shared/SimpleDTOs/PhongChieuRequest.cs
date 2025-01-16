using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{
    public class PhongChieuRequest
    {
        public string Ten { get; set; } // Tên phòng chiếu
        public int SoHang { get; set; } // Số hàng ghế
        public int SoCot { get; set; } // Số cột ghế
        public string Layout { get; set; } // Sơ đồ ghế dạng ma trận
        public Metadata Metadata { get; set; } //thông số sơ đồ ghế
        public double HeSoGia { get; set; } // Hệ số giá của phòng chiếu
    }
}
