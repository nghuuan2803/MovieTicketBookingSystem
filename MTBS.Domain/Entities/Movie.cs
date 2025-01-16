using MTBS.Domain.Abstracts;

namespace MTBS.Domain.Entities
{
    public class Movie : BaseEntity<int>
    {
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? StudioId { get; set; } = string.Empty;
        public string? DirectorId { get; set; } = string.Empty;
        public DateTimeOffset ReleaseDate { get; set; }
        public int Duration { get; set; }
        public bool IsOpen { get; set; }

        public Studio? Studio { get; set; }
        public Director? Director { get; set; }

        public virtual ICollection<Actor>? Actors { get; set; }
    }
}
