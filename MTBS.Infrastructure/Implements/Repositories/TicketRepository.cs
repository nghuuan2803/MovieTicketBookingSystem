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
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Ticket> FindAsync(Expression<Func<Ticket, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbContext.Tickets.Include(p=>p.Seat).FirstOrDefaultAsync(predicate, cancellationToken)!;
        }
    }
}
