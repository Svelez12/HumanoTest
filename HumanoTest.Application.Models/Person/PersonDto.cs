namespace HumanoTest.Application.Models.Person;

using HumanoTest.Application.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

public class PersonDto : BaseDto
{
    public PersonDto()
    {
    }

    public PersonDto(int id) : base(id)
    {
    }

    public PersonDto(int id, int identityNumber, string name, int age, ICollection<PersonContactDto> contacts) : base(id)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
        Contacts = contacts;
    }

    public PersonDto(int id, int identityNumber, string name, int age, IEnumerable<PersonContactDto> iEContacts) : base(id)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
        IEContacts = iEContacts;
    }

    public PersonDto(int identityNumber, string name, int age)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    [Required]
    public int IdentityNumber { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    public ICollection<PersonContactDto> Contacts { get; set; }

    public IEnumerable<PersonContactDto> IEContacts { get; set; }
}