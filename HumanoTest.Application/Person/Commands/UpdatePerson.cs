namespace HumanoTest.Application.Person.Commands;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Models.BaseModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

public class UpdatePerson : BaseDto, IRequest<ResponseData>
{
    public UpdatePerson()
    {
    }

    public UpdatePerson(int id, string identityNumber, string name, int age) : base(id)
    {
        Id = id;
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    [Required]
    [MaxLength(12)]
    public string IdentityNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }
}