using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.CinemaDTOs
{
    public class UpdateCinemaRequest
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Address { get; set; }

        public string? Image { get; set; }

        public string? UpdateBy { get; set; }
    }
}
