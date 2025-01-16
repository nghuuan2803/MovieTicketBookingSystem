using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{

    public class SeatLayout
    {
        public string Layout { get; set; }
        public Metadata? Metadata { get; set; }
    }

    public class Metadata
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[] Center { get; set; }
        public int[] LoiDi { get; set; }
    }

}
