using MTBS.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace MTBS.Domain.Entities
{
    public class Movie : BaseEntity<int>
    {
        [MaxLength(100)]
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Genre { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Categories { get; set; } = string.Empty; //json: 2D/3D

        [MaxLength(200)]
        public string? Thumbnail { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Studio { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Director { get; set; } = string.Empty;

        public string? Actors { get; set; } = string.Empty;
        public DateTimeOffset ReleaseDate { get; set; }
        public int Duration { get; set; }
        public bool IsOpen { get; set; }

        //public double Rating { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<Trailer>? Trailers { get; set; }
    }
}
