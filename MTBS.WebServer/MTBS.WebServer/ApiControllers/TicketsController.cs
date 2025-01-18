using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Infrastructure;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.Tickets.ToListAsync());
        }
    }
}
