using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class PhongChieu
    {
        [Key]
        public int Id { get; set; }
        public string? Ten { get; set; }
        public int SoGhe { get; set; }
        public int SoHang { get; set; }
        public int SoCot { get; set; }
        public string? Layout { get; set; }
        public string? Metadata { get; set; }
        public double HeSoGia { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Ghe>? DsGhe { get; set; }
    }
}
