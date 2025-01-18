using MediatR;
using MTBS.Domain.Entities;
using MTBS.Shared.CinemaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Features.Cinemas.Commands
{
    public class AddCinemaCommand : IRequest<Result<Cinema>>
    {
        public required AddCinemaRequest Request { get; set; }
        public string? UserName { get; set; }
    }
}
