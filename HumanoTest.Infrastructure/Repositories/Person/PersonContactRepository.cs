namespace HumanoTest.Infrastructure.Repositories.Person;

using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Domain.Entities.PersonEntities;
using HumanoTest.Infrastructure.Contracts.DbContext;
using HumanoTest.Infrastructure.Repositories.Generic;

public class PersonContactRepository : GenericRepository<PersonContact>, IPersonContactRepository
{
    public PersonContactRepository(IHumanoTestDbContext humanoTestDbContext) : base(humanoTestDbContext)
    {
    }
}
