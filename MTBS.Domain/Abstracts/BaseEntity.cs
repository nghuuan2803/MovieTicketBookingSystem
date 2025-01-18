using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Abstracts
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        [MaxLength(32)]
        public string? CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
        [MaxLength(32)]
        public string? UpdatedBy { get; set; }
    }
}
