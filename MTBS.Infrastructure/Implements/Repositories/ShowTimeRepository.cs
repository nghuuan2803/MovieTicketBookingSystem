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
    public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
    {
        public ShowTimeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override Task<ShowTime> FindAsync(Expression<Func<ShowTime, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.ShowTimes.Include(p=>p.Tickets).FirstOrDefaultAsync(predicate, cancellationToken)!;
        }
    }
}
