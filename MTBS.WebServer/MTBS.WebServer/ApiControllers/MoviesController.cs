using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Entities;
using MTBS.Infrastructure;
using MTBS.Shared.MovieDTOs;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await db.Movies.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMovieRequest request)
        {
            var movie = mapper.Map<Movie>(request);
            await db.Movies.AddAsync(movie);
            await db.SaveChangesAsync();
            return Ok(movie);
        }
    }
}
