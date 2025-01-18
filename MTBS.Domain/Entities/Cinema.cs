using MTBS.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace MTBS.Domain.Entities
{
    public class Cinema : BaseEntity<int>
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? Image { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Hall>? Halls { get; set; }
    }
}
