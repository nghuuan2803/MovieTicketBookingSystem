using MTBS.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Promotion : BaseEntity<int>
    {
        public DateTimeOffset BeginAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
        public string? Description { get; set; }
        public int Type { get; set; }
        public double DiscountValue { get; set; }
        public double Maximum { get; set; } = 0;
        [MaxLength(200)]
        public string? Requirement { get; set; }
    }
}
