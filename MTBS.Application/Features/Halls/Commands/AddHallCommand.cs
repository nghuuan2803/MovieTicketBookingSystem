using MediatR;
using MTBS.Domain.Entities;
using MTBS.Shared.HallDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Halls.Commands
{
    public class AddHallCommand : IRequest<Result<Hall>>
    {
        public required AddHallRequest Request { get; set; }
        public string? Sender { get; set; }
    }
}
