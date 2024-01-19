namespace HumanoTest.Application.Person.Commands;

using HumanoTest.Application.Models.Person;
using MediatR;
using System.ComponentModel.DataAnnotations;
using HumanoTest.Application.Contracts;

public class CreatePerson : IRequest<ResponseData>
{
    [Required]
    public string IdentityNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    public IEnumerable<PersonContactCreateDto>? Contacts { get; set; }
}