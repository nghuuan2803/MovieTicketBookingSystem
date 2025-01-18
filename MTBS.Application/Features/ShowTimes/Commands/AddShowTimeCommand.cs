using MediatR;
using MTBS.Domain.Entities;
using MTBS.Shared.ShowTimeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.ShowTimes.Commands
{
    public class AddShowTimeCommand : IRequest<Result<ShowTime>>
    {
        public required AddShowTimeRequest Request { get; set; }
        public string? Sender { get; set; }
    }
}
