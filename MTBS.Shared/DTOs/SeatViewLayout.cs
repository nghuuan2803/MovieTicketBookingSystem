﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.DTOs
{
    public class SeatViewLayout
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public SeatView[,] SeatViews { get; set; }
    }
}
