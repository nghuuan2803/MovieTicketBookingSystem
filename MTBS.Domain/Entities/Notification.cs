using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public string? Title { get; set; }
        public required string Content { get; set; }
        [MaxLength(100)]
        public string? NavigateUrl { get; set; }
        public bool IsChecked { get; set; }

        public User? User { get; set; }
    }
}
