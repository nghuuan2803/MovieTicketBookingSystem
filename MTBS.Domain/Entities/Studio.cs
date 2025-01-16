using MTBS.Domain.Abstracts;

namespace MTBS.Domain.Entities
{
    public class Studio : BaseEntity<int>
    {
        public required string Name { get; set; }
    }
}
