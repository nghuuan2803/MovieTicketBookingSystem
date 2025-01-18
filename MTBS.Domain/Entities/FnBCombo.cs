using MTBS.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class FnBCombo : BaseEntity<int>
    {
        [MaxLength(100)]
        public required string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public double Price { get; set; }

        [MaxLength(50)]
        public string? Image { get; set; }

        public bool IsDeleted { get; set; }
    }
}
