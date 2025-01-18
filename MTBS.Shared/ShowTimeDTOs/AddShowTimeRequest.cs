using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.ShowTimeDTOs
{
    public class AddShowTimeRequest
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime BeginAt { get; set; }
        public bool IsCanceled { get; set; }
        public string? Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
