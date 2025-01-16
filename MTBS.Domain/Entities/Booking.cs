using MTBS.Domain.Abstracts;
using MTBS.Domain.Entities.Auth;
using MTBS.Domain.Values;

namespace MTBS.Domain.Entities
{
    public class Booking : BaseEntity<Guid>
    {
        public required string UserId { get; set; }
        public double Amount { get; set; }
        public double Final { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Creating;

        public User? User { get; set; }

        public virtual ICollection<BookingTicket>? BookingTickets { get; set; }
    }
}
