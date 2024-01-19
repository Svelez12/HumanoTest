namespace HumanoTest.Infrastructure;

using HumanoTest.Domain.Entities.PersonEntities;
using HumanoTest.Infrastructure.Contracts.DbContext;
using HumanoTest.Infrastructure.EntitiesConfig.Person;
using Microsoft.EntityFrameworkCore;

public class HumanoTestDbContext : DbContext, IHumanoTestDbContext
{
    public HumanoTestDbContext(DbContextOptions<HumanoTestDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Person { get; set; }
    public DbSet<PersonContact> PersonContact { get; set; }
    public DbSet<PersonContactType> PersonContactType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Eliminate the Delete in Cascade
        //var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        //                .SelectMany(t => t.GetForeignKeys())
        //                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Restrict);

        //foreach (var fk in cascadeFKs)
        //{
        //    fk.DeleteBehavior = DeleteBehavior.Cascade;
        //}

        //Database Schema.
        //modelBuilder.HasDefaultSchema("Person");

        //Entities Config.
        ModelConfig(modelBuilder);
    }

    private static void ModelConfig(ModelBuilder modelBuilder)
    {
        PersonConfig.SetEntityBuilderSQLServer(modelBuilder.Entity<Person>());
        PersonContactConfig.SetEntityBuilderSQLServer(modelBuilder.Entity<PersonContact>());
        PersonContactTypeConfig.SetEntityBuilderSQLServer(modelBuilder.Entity<PersonContactType>());
    }
}