using MTBS.Domain.Abstracts.Repositories;
using MTBS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace MTBS.Infrastructure.MockData.MockRepos
//{
//    public class MockMovieRepo : IMovieRepository
//    {
//        public Task AddAsync(Movie entity)
//        {
//            return Task.CompletedTask;
//        }

//        public Task AddRangeAsync(IEnumerable<Movie> entities)
//        {
//            return Task.CompletedTask;
//        }

//        public async Task<Movie> FindAsync(Expression<Func<Movie, bool>> predicate)
//        {
//            return new Movie() { Name = "Avenger: Endgame"};
//        }

//        public async Task<Movie> FindAsync(object id)
//        {
//            return new Movie() { Name = "Avenger: Endgame" };
//        }

//        public Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> predicate = null, CancellationToken cancellationToken = default)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(Movie entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> RemoveByIdAsync(object id)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveRange(IEnumerable<Movie> entities)
//        {
//            throw new NotImplementedException();
//        }

//        public Task RemoveRangeByIdsAsync(IEnumerable<object> ids)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Movie entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateRange(IEnumerable<Movie> entities)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
