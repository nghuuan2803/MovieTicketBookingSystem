using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.Implements.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
