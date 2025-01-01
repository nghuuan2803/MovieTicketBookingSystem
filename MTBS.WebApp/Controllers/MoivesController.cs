using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBS.Domain.Abstracts.Repositories;

namespace MTBS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoivesController(IMovieRepository _data) : ControllerBase
    {
        [HttpGet("/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var movie = await _data.FindAsync(id);
            return Ok(movie);
        }
    }
}
