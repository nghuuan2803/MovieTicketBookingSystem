using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.Implements.Repositories
{
    public class HallRepository : GenericRepository<Hall>, IHallRepository
    {
        public HallRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Hall> FindAsync(Expression<Func<Hall, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Halls.Include(p => p.Seats).FirstOrDefaultAsync(predicate, cancellationToken);
        }
    }
}
