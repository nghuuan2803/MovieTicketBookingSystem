using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.SimpleDTOs
{
    public class ChonGheRequest
    {
        public int XuatChieuId { get; set; }

        public int VeId { get; set; }

        public string? HubConnectionId { get; set; }
    }
    public class NhaGheRequest : ChonGheRequest { }
}
