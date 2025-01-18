using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class BookingFnBCombo
    {
        public Guid BookingId { get; set; }
        public int FnBComboId { get; set; }
        public double Price { get; set; }

        public Booking? Booking { get; set; }
        public FnBCombo? FnBCombo { get; set; }
    }
}
