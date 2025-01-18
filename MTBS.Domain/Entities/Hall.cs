using MTBS.Domain.Abstracts;
using MTBS.Domain.Values;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTBS.Domain.Entities
{
    public class Hall : BaseEntity<int>
    {
        [MaxLength(10)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public required string Type { get; set; } = HallType.Standart;
        public string? Layout { get; set; }
        [MaxLength(200)]
        public string? Metadata { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double PriceCoefficient { get; set; } = 1.0;
        public bool IsOpen { get; set; } = true;


        public int CinemaId { get; set; }
        [JsonIgnore]
        public Cinema? Cinema { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Seat>? Seats { get; set; }
    }
}
