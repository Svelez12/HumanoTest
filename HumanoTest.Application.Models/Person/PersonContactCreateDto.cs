namespace HumanoTest.Application.Models.Person;

using System.ComponentModel.DataAnnotations;

public class PersonContactCreateDto
{
    public PersonContactCreateDto()
    {
            
    }
    public PersonContactCreateDto(int personContactTypeId, string contactName, string data, bool isMainContact)
    {
        PersonContactTypeId = personContactTypeId;
        ContactName = contactName;
        Data = data;
        IsMainContact = isMainContact;
    }

    [Required]
    public int PersonContactTypeId { get; set; }


    [Required]
    [MaxLength(100)]
    public string ContactName { get; set; }

    [Required]
    [MaxLength(600)]
    public string Data { get; set; }

    public bool IsMainContact { get; set; }
}
