namespace HumanoTest.Application.Person.CommandHandlers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Person.Commands;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Domain.Entities.PersonEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CreatePersonHandler : IRequestHandler<CreatePerson, ResponseData>
{
    private readonly IPersonUnitOfWork personUnitOfWork;

    public CreatePersonHandler(IPersonUnitOfWork PersonUnitOfWork)
    {
        personUnitOfWork = PersonUnitOfWork;
    }

    public async Task<ResponseData> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        Person person = new(request.IdentityNumber, request.Name, request.Age);
        List<PersonContact> personContacts = request.Contacts == null ? new List<PersonContact>() : request.Contacts?.Select(contact =>
            new PersonContact(contact.PersonContactTypeId, contact.ContactName, contact.Data, person, contact.IsMainContact))
            .ToList();

        await personUnitOfWork.PersonRepository.CreateAsync(person);

        await personUnitOfWork.PersonContactRepository.AddRangeAsync(personContacts);

        return await personUnitOfWork.SaveChangesAsync();
    }
}