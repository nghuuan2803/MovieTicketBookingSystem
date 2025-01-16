using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Abstracts;
using MTBS.Domain.SampleModels;
using MTBS.Infrastructure;

namespace MTBS.WebApp.SimpleAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T> : ControllerBase
        where T : class
    {
        protected readonly AppDbContext db;
        protected DbSet<T> dbSet;

        public GenericController(AppDbContext dbContext)
        {
            db = dbContext;
            dbSet = dbContext.Set<T>();
        }
        [HttpGet]
        public virtual async Task<IActionResult> Get(CancellationToken cancellation)
        {
            return Ok(await dbSet.ToListAsync(cancellation));
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id, CancellationToken cancellation)
        {
            return Ok(await dbSet.FindAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] T model, CancellationToken cancellation)
        {
            await dbSet.AddAsync(model);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T model, CancellationToken cancellation)
        {
            dbSet.Update(model);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id, CancellationToken cancellation)
        {
            var model = await dbSet.FindAsync(id);
            if (model != null)
            {
                dbSet.Remove(model);
                await db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
