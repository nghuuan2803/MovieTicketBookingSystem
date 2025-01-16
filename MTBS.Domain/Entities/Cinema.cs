using MTBS.Domain.Abstracts;

namespace MTBS.Domain.Entities
{
    public class Cinema : BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? Address { get; set; }
    }
}
