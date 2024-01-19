namespace HumanoTest.Infrastructure.Repositories.Person;

using HumanoTest.Infrastructure.Repositories.Generic;
using HumanoTest.Infrastructure.Contracts.DbContext;
using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Domain.Entities.PersonEntities;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(IHumanoTestDbContext humanoTestDbContext) : base(humanoTestDbContext)
    {
    }
}