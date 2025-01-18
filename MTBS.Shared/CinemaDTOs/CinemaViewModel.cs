using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.CinemaDTOs
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

        //public string CreatedBy { get; set; } = string.Empty;

        //public string? UpdatedBy { get; set; }

        //public DateTimeOffset CreatedAt { get; set; }

        //public DateTimeOffset? UpdateddAt { get; set; }
    }
}
