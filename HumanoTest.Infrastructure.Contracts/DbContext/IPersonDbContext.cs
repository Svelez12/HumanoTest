namespace HumanoTest.Infrastructure.Contracts.DbContext;

using HumanoTest.Domain.Entities.PersonEntities;
using Microsoft.EntityFrameworkCore;

public interface IPersonDbContext
{
    DbSet<Person> Person { get; set; }

    DbSet<PersonContact> PersonContact { get; set; }

    DbSet<PersonContactType> PersonContactType { get; set; }
}