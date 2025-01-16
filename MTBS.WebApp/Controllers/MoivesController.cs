using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBS.Domain.Abstracts.Repositories;
using Newtonsoft.Json;

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

        [HttpGet]
        public ActionResult Layout()
        {
            int[,] matrix =
            {
                { 0, 1, 2, },
                { 1, 2, 3, }
            };
            var rs = new {matrix = matrix};

            string response = JsonConvert.SerializeObject(rs);
            return Ok(response);
        }
    }
}
