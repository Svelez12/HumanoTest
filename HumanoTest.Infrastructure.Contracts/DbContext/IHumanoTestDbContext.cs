namespace HumanoTest.Infrastructure.Contracts.DbContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface IHumanoTestDbContext : IPersonDbContext
{
    DatabaseFacade Database { get; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    void RemoveRange(IEnumerable<object> entities);

    EntityEntry Update(object entity);

    EntityEntry Entry(object entity);
}