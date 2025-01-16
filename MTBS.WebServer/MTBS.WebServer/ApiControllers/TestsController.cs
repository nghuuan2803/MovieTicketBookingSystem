using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTBS.WebServer.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hello");
        }
    }
}
