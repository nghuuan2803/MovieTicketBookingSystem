using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.Implements.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
