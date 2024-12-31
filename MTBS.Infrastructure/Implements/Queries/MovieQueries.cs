using MTBS.Application;
using MTBS.Application.DTOs;
using MTBS.Application.Features;
using MTBS.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure.Implements.Queries
{
    public class MovieQueries : IMovieQueries
    {
        public Task<IEnumerable<MovieModel>> GetAll(IEnumerable<string>? sortBy = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<MovieModel> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedData<MovieModel>> GetFilteredPage(int pageIndex = 0, int pageSize = 0, FilterMovieQuery? filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PagedData<MovieModel>> GetPage(int pageIndex = 0, int pageSize = 0, IEnumerable<string>? sortBy = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
