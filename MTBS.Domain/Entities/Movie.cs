using MTBS.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Movie : BaseEntity<Guid>
    {
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Studio { get; set; } = string.Empty;
        public string? Director { get; set; } = string.Empty;
        public string? Actors { get; set; } = string.Empty; //Json
        public DateTimeOffset ReleaseDate { get; set; }
        public int Duration { get; set; }
        public bool IsOpen { get; set; }
    }
}
