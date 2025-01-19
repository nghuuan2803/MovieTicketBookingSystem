using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Application.Features.ShowTimes.Commands;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Infrastructure;
using MTBS.Shared.ShowTimeDTOs;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController(IMediator mediator, AppDbContext db, IShowTimeRepository showTimeRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddShowTimeRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new AddShowTimeCommand { Request = request };
            var result = await mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var showtime = await db.ShowTimes.Include(p => p.Tickets).FirstOrDefaultAsync(p => p.Id == id);

            return showtime == null ? NotFound() : Ok(showtime);
        }

        [HttpGet("Schedule")]
        public async Task<IActionResult> GetSchedule()
        {
            return Ok(await showTimeRepository.GetSchedule());
        }
    }
}
