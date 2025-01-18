using MTBS.Domain.Abstracts;
using MTBS.Domain.Values;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTBS.Domain.Entities
{
    public class Seat: BaseEntity<int>
    {
        [MaxLength(3)]
        public required string Name { get; set; }
        public int HallId { get; set; }

        [MaxLength(10)]
        public string Type { get; set; } = SeatType.Single;

        public int Row { get; set; }
        public int Colums { get; set; }

        public double PriceCoefficient { get; set; } = 1; //hệ số giá vé
        public bool IsMaitance { get; set; }
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public Hall? Hall { get; set; }
    }
}
