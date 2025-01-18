using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{
    public class Metadata
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public required int[] Center { get; set; }
        public required int[] FootPath { get; set; }
    }
}
