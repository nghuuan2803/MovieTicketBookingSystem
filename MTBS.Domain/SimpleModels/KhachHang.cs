using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }

        [JsonIgnore]
        public virtual ICollection<HoaDon>? DsHoaDon { get; set; }
    }
}
