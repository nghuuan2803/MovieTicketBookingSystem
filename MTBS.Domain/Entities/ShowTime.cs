using MTBS.Domain.Abstracts;

namespace MTBS.Domain.Entities
{
    public class ShowTime : BaseEntity<Guid>
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime BeginAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int BookedSeat { get; set; }
        public bool ICanceled { get; set; }

        public Movie? Movie { get; set; }
        public Hall? Hall { get; set; }

        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
