using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features
{
    public class FilterMovieQuery
    {
        public IEnumerable<string>? SortBy { get; set; }

        public string? Studio { get; set; }

        public string? Genre { get; set; }

        public string? Director { get; set; }

        public string? Actor { get; set; }

        public DateTimeOffset? ReleaseDateFrom { get; set; }
        public DateTimeOffset? ReleaseDateTo { get; set; }

        public bool? IsOpen { get; set; }
    }
}
