using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.DbContexts
{
    public class TestTable
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
