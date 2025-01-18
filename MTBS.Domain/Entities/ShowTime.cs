using MTBS.Domain.Abstracts;
using System.Text.Json.Serialization;

namespace MTBS.Domain.Entities
{
    public class ShowTime : BaseEntity<Guid>
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime BeginAt { get; set; }
        public DateTime? EndAt { get; set; }
        public bool IsCanceled { get; set; }
        public string? Category { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public Movie? Movie { get; set; }
        [JsonIgnore]
        public Hall? Hall { get; set; }

        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
