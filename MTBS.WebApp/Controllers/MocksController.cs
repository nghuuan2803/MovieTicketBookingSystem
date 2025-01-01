using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBS.Infrastructure.DbContexts;
using MTBS.Infrastructure.MockData.MockRepos;

namespace MTBS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MocksController(MockTable table) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TestTable record)
        {
            table.Insert(record);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(table.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message+" - " + ex.StackTrace);
            }
            
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(table.GetRecord(id));
        }
    }
}
