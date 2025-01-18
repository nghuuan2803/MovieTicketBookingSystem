using MTBS.Domain.Abstracts;
using MTBS.Domain.Values;
using System.ComponentModel.DataAnnotations;

namespace MTBS.Domain.Entities
{
    public class Booking : BaseEntity<Guid>
    {
        public double Amount { get; set; }
        public double Final { get; set; }
        [MaxLength(15)]
        public string? PaymentMethod { get; set; } = "Momo";
        public DateTimeOffset? PaymentDate { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Creating;

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public int? VoucherId { get; set; }
        public Voucher? Voucher { get; set; }

        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public virtual ICollection<BookingTicket>? BookingTickets { get; set; }
        public virtual ICollection<BookingFnBCombo>? BookingFnBCombos { get; set; }
    }
}
