using MTBS.Domain.Abstracts;
using MTBS.Domain.Values;

namespace MTBS.Domain.Entities
{
    public class Seat: BaseEntity<int>
    {
        public required string Name { get; set; }
        public int HallId { get; set; }
        public string Site { get; set; } = SeatSite.Left;
        public string Type { get; set; } = SeatType.Single;
        public SiteBorder SiteBorder { get; set; } = SiteBorder.None;
        public int Row { get; set; }
        public int Colums { get; set; }

        public Hall? Hall { get; set; }
    }
}
