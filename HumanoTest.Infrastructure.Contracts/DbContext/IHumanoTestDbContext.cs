namespace HumanoTest.Infrastructure.Contracts.DbContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

public interface IHumanoTestDbContext : IPersonDbContext
{
    // Propiedades
    ChangeTracker ChangeTracker { get; }

    DatabaseFacade Database { get; }

    // Métodos de instancia
    EntityEntry Entry(object entity);

    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    void RemoveRange(IEnumerable<object> entities);

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    EntityEntry Update(object entity);

    // Métodos de extensión
    void Dispose();
}