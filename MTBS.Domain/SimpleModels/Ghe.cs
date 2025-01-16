using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SampleModels
{
    public class Ghe
    {
        [Key]
        public int Id { get; set; }
        public string SoGhe { get; set; }
        public int LoaiGhe { get; set; }
        public double HeSoGia { get; set; }
        public int Hang { get; set; }
        public int Cot { get; set; }

        public int PhongChieuId { get; set; }
        [JsonIgnore]
        public PhongChieu? PhongChieu { get; set; }
    }
}
