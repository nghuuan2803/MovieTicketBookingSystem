using Microsoft.EntityFrameworkCore;
using MTBS.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<T> entities)
        {
            return _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            CancellationToken cancellationToken = default)
        {
            return await (predicate == null ?
                _dbContext.Set<T>().ToListAsync(cancellationToken) :
                _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken));
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> RemoveByIdAsync(object id)
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
                return false;
            _dbContext.Set<T>().Remove(entity);
            return true;
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task RemoveRangeByIdsAsync(IEnumerable<object> ids)
        {
            List<T> entities = new List<T>();
            foreach(var id in ids)
            {
                var entity =  await _dbContext.Set<T>().FindAsync(id);
                if(entity != null)
                {
                    entities.Add(entity);
                }
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
