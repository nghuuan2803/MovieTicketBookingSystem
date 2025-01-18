using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Application.Features.Halls.Commands;
using MTBS.Infrastructure;
using MTBS.Shared.HallDTOs;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _dbContext;
        public HallsController(IMediator mediator, AppDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHallRequest request)
        {
            var command = new AddHallCommand { Request = request };
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.Halls.Include(p=>p.Seats).ToListAsync());
        }
    }
}
