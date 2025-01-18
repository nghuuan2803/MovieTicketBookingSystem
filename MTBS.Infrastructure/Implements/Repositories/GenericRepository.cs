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

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> predicate, 
            CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> FindAsync(object id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            CancellationToken cancellationToken = default)
        {
            return await (predicate == null ?
                _dbContext.Set<T>().ToListAsync(cancellationToken) :
                _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken));
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<bool> RemoveByIdAsync(object id,
            CancellationToken cancellationToken = default)
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
                return false;
            _dbContext.Set<T>().Remove(entity);
            return true;
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public virtual Task SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        //public async Task RemoveRangeByIdsAsync(IEnumerable<object> ids)
        //{
        //    List<T> entities = new List<T>();
        //    foreach (var id in ids)
        //    {
        //        var entity = await _dbContext.Set<T>().FindAsync(id);
        //        if (entity != null)
        //        {
        //            entities.Add(entity);
        //        }
        //    }
        //}

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
