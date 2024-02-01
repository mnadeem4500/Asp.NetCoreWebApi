using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ExtremeClassified.Core.Contracts.EntityFramwork
{
    public interface IDbContext
    {
        Guid InstanceId { get; }
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void SyncObjectState(object entity);
        DatabaseFacade GetDatabase();

        int BatchSize { get; set; }
        long ExecuteBulkInsert<T>(params T[] entities) where T : class;
    }
}
