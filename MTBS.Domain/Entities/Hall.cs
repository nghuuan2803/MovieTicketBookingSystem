using MTBS.Domain.Abstracts;
using MTBS.Domain.Values;

namespace MTBS.Domain.Entities
{
    public class Hall : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Type { get; set; } = HallType.Standart;
        public string? Layout { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool IsOpen { get; set; } = true;

        public Guid CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
