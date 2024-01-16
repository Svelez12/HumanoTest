namespace HumanoTest.Domain.Contracts.IRepositories.Person;

using HumanoTest.Domain.Contracts.IRepositories.Generic;
using Domain.Entities.Person;

public partial interface IPersonRepository : IGenericRepository<Person>
{
}