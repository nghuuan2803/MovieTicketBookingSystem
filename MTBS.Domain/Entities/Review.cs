using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Review
    {
        [Key]
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        public string? Content { get; set; }
        public double Rating { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsEdited { get; set; }

        public User? User { get; set; }
        public Movie? Movie { get; set; }

    }
}
