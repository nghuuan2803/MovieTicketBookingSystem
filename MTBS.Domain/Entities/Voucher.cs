using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int Type { get; set; }
        public int DiscountValue { get; set; }
        public int Expired { get; set; } = 30;
        public bool IsDeleted { get; set; }

        [MaxLength(100)]
        public string? Image { get; set; }
    }
}
