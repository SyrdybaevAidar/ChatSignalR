using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed;
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }

        public DbSet<T> GetRepository<T>() where T : class
            => _context.Set<T>();

        public async Task SaveChangesAsync(CancellationToken token = default) { 
            await _context.SaveChangesAsync(token);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token = default)
        {
            var result = await _context.Database.BeginTransactionAsync(token);
            return result;
        }

        public async Task CommitTransactionsAsync(CancellationToken token = default)
        {
            await _context.Database.CommitTransactionAsync(token);
        }

        public async Task RollbackTransationsAsync(CancellationToken token = default)
        {
            await _context.Database.RollbackTransactionAsync(token);
        }

        #region Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
