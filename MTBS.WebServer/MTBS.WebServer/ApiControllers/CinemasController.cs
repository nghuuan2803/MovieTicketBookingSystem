using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBS.Application;
using MTBS.Application.Features.Cinemas.Commands;
using MTBS.Domain.Entities;
using MTBS.Shared.CinemaDTOs;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add(AddCinemaRequest request)
        {
            var command = new AddCinemaCommand { Request = request };
            var result = (await mediator.Send(command));
            return Ok(result.Data);
        }
    }
}
