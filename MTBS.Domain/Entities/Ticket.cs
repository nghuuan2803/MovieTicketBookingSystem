using MTBS.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MTBS.Domain.Entities
{
    public class Ticket : BaseEntity<Guid>
    {
        public int SeatId { get; set; }
        public Guid ShowTimeId { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        [MaxLength(50)]
        public string? HoldBy { get; set; }
        public bool IsCheckedin { get; set; }

        //[JsonIgnore]
        public Seat? Seat { get; set; }
        [JsonIgnore]
        public ShowTime? ShowTime { get; set; }
    }
}
