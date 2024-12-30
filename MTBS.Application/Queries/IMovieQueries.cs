using MTBS.Application.DTOs;
using MTBS.Application.Features.MovieManagement.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Application.Queries
{
    public interface IMovieQueries
    {
        Task<IEnumerable<MovieModel>> GetAll(IEnumerable<string>? sortBy = null,
            CancellationToken cancellationToken = default);

        Task<PagedData<MovieModel>> GetPage(int pageIndex = 0, int pageSize = 0,
            IEnumerable<string>? sortBy = null,
            CancellationToken cancellationToken = default);

        Task<PagedData<MovieModel>> GetFilteredPage(int pageIndex = 0,
            int pageSize = 0, FilterMovieQuery? filter = null,
            CancellationToken cancellationToken = default);

        Task<MovieModel> GetById(object id);
    }
}
