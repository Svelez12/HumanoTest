namespace HumanoTest.Application.Person.CommandHandlers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Person.Commands;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Domain.Entities.PersonEntities;
using MediatR;

public class UpdatePersonHandler : IRequestHandler<UpdatePerson, ResponseData>
{
    private readonly IPersonUnitOfWork personUnitOfWork;

    public UpdatePersonHandler(IPersonUnitOfWork PersonUnitOfWork)
    {
        personUnitOfWork = PersonUnitOfWork;
    }

    public async Task<ResponseData> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        if(await personUnitOfWork.PersonRepository.ExistAsync(request.Id))
        {
            Person person = new(request.Id, request.IdentityNumber, request.Name, request.Age);

            await personUnitOfWork.PersonRepository.UpdateAsync(person);

            return await personUnitOfWork.SaveChangesAsync();
        }

        return new ResponseData(false, "Id no encontrado.");
    }
}