namespace HumanoTest.Infrastructure.Contracts.DbContext;

using HumanoTest.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;

public interface IPersonDbContext
{
    DbSet<Person> Person { get; set; }

    DbSet<PersonContact> PersonContact { get; set; }

    DbSet<PersonContactType> PersonContactType { get; set; }
}