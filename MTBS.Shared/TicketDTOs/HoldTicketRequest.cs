using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.TicketDTOs
{
    public class HoldTicketRequest
    {
        public Guid ShowTimeId { get; set; }
        public int TicketId { get; set; }
        public string? HubConnectionId { get; set; }
        public string? UserId { get; set; }
    }
}
