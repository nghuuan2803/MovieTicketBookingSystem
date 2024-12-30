using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollBackAsync();
        Task SaveChangesAsync();
    }
}
