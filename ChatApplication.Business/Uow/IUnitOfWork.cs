using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Uow
{
    public interface IUnitOfWork
    {
        DbSet<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync(CancellationToken token = default);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token = default);
        Task CommitTransactionsAsync(CancellationToken token = default);
        Task RollbackTransationsAsync(CancellationToken token = default);
    }
}
