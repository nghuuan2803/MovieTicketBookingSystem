using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.DTOs
{
    public class SeatView
    {
        public bool IsSeat { get; set; }
        public SeatInfo Info { get; set; }
    }
    public class SeatInfo
    {
        public string SeatNumber { get; set; }
        public string? TicketId { get; set; }
        public int Type { get; set; } // 1: standart, 2: couple
    }
}
