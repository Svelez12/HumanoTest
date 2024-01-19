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
        List<Person> people = request.Ids.Where(p => p > 0).Select(p => new Person(p)).ToList();

        await personUnitOfWork.PersonRepository.DeleteRangeAsync(people.ToArray());

        return await personUnitOfWork.SaveChangesAsync();
    }
}