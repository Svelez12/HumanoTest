namespace HumanoTest.Infrastructure.Repositories.Person;

using HumanoTest.Infrastructure.Repositories.Generic;
using Domain.Entities.Person;
using HumanoTest.Infrastructure.Contracts.DbContext;
using HumanoTest.Domain.Contracts.IRepositories.Person;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(IHumanoTestDbContext humanoTestDbContext) : base(humanoTestDbContext)
    {
    }
}