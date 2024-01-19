namespace HumanoTest.Application.Person.CommandHandlers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Person.Commands;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HumanoTest.Domain.Entities.PersonEntities;

public class DeletePersonHandler : IRequestHandler<DeletePerson, ResponseData>
{
    private readonly IPersonUnitOfWork personUnitOfWork;

    public DeletePersonHandler(IPersonUnitOfWork PersonUnitOfWork)
    {
        personUnitOfWork = PersonUnitOfWork;
    }

    public async Task<ResponseData> Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        List<Person> people = new();

        foreach (var id in request.Ids)
        {
            if (id > 0)
            {
                people.Add(new Person(id));
            }
        }

        await personUnitOfWork.PersonRepository.DeleteRangeAsync(people.ToArray());

        return await personUnitOfWork.SaveChangesAsync();
    }
}