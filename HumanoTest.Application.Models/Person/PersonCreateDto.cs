namespace HumanoTest.Application.Models.Person;

using System.ComponentModel.DataAnnotations;

public class PersonCreateDto
{
    public PersonCreateDto()
    {
    }

    public PersonCreateDto(int identityNumber, string name, int age, IEnumerable<PersonContactCreateDto> contacts)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
        Contacts = contacts;
    }

    public PersonCreateDto(int identityNumber, string name, int age)
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

    public IEnumerable<PersonContactCreateDto>? Contacts { get; set; }
}