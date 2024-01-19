namespace HumanoTest.Application.Person.QueryHandlers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Models.Common;
using HumanoTest.Application.Models.Person;
using HumanoTest.Application.Person.Queries;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Domain.Entities.PersonEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetAllPersonHandler : IRequestHandler<GetAllPersons, ResponseData>
{
    private readonly IPersonUnitOfWork personUnitOfWork;

    public GetAllPersonHandler(IPersonUnitOfWork PersonUnitOfWork)
    {
        personUnitOfWork = PersonUnitOfWork;
    }

    public async Task<ResponseData> Handle(GetAllPersons request, CancellationToken cancellationToken)
    {
        return await personUnitOfWork.PersonRepository.GetAllDataAsync(request.Page, request.Take,
           select: x => new PersonDto(x.Id, x.IdentityNumber, x.Name, x.Age,
           x.Contacts.Select(x => new PersonContactDto(x.ContactName, x.Data, x.IsMainContact, x.PersonContactType.Name))), null,
           new List<WhereIfModel<Person>> {
               new WhereIfModel<Person>(request.IdentityNumber!= string.Empty, c => c.IdentityNumber==request.IdentityNumber)
           });
    }
}