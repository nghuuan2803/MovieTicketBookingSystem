using MTBS.Domain.SampleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTBS.Domain.SimpleModels
{
    public class ChiTietHD
    {
        [Key]
        public int Id { get; set; }
        public double GiaCuoi { get; set; }

        public int HoaDonId { get; set; }
        [JsonIgnore]
        public HoaDon? HoaDon { get; set; }

        public int VeId { get; set; }
        [JsonIgnore]
        public Ve? Ve { get; set; }
    }
}
