using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Trailer
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        [MaxLength(100)]
        public string? Url { get; set; }
        [MaxLength(100)]
        public string? Thumbail { get; set; }

        public Movie? Movie { get; set; }
    }
}
