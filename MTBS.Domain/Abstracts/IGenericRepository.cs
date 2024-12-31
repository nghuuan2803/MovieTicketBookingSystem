using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Abstracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null!,
            CancellationToken cancellationToken = default);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(object id);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);
        Task<bool> RemoveByIdAsync(object id);
        void RemoveRange(IEnumerable<T> entities);
        Task RemoveRangeByIdsAsync(IEnumerable<object> ids);
    }
}
