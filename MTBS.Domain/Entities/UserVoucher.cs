using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class UserVoucher
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int VoucherId { get; set; }
        public DateTimeOffset Expired { get; set; }

        public User? User { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
