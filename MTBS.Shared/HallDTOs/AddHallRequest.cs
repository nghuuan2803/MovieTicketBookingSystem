using MTBS.Shared.SimpleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.HallDTOs
{
    public class AddHallRequest
    {
        public required string Name { get; set; } // Tên phòng chiếu
        public int CinemaId { get; set; } // Tên phòng chiếu
        public int Rows { get; set; } // Số hàng ghế
        public int Columns { get; set; } // Số cột ghế
        public required string Layout { get; set; } // Sơ đồ ghế dạng ma trận
        public Metadata? Metadata { get; set; } //thông số sơ đồ ghế
        public double PriceCoefficient { get; set; } // Hệ số giá của phòng chiếu
    }
}
