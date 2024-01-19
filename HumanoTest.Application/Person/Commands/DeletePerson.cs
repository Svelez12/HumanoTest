namespace HumanoTest.Application.Person.Commands;

using HumanoTest.Application.Contracts;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class DeletePerson : IRequest<ResponseData>
{
    public DeletePerson()
    {
    }

    public DeletePerson(IList<int> ids)
    {
        Ids = ids;
    }

    [Required]
    public IList<int> Ids { get; set; }
}