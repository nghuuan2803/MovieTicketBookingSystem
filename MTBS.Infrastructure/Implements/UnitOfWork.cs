using Microsoft.EntityFrameworkCore.Storage;
using MTBS.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Infrastructure
{
    public class UnitOfWork(AppDbContext _db) : IUnitOfWork
    {
        private IDbContextTransaction _transaction = null!;

        public async Task BeginAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
            DisposeTransaction();
        }

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }
        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null!;
            }
        }
        public void Dispose()
        {
            DisposeTransaction();
            _db.Dispose();
        }
    }
}
