using MTBS.Domain.Abstracts;

namespace MTBS.Domain.Entities
{
    public class Ticket : BaseEntity<Guid>
    {
        public int SeatId { get; set; }
        public Guid ShowTimeId { get; set; }
        public double Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
