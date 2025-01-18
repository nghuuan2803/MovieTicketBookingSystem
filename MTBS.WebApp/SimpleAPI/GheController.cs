using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.SampleModels;
using MTBS.Infrastructure;

//namespace MTBS.WebApp.SimpleAPI
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GheController : GenericController<Ghe>
//    {
//        public GheController(AppDbContext dbContext) : base(dbContext)
//        {
//        }
//        [HttpGet("GetByPhongChieuId/{id}")]
//        public async Task<IActionResult> GetByPhongChieuId(int id, CancellationToken cancellationToken)
//        {
//            return Ok(await dbSet.Where(p => p.PhongChieuId == id).ToListAsync(cancellationToken));
//        }
//    }
//}
