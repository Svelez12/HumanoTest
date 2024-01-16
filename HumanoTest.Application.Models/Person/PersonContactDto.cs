namespace HumanoTest.Application.Models.Person;

using HumanoTest.Application.Models.BaseModels;

public class PersonContactDto : BaseDto
{
    public PersonContactDto()
    {
    }

    public PersonContactDto(int id) : base(id)
    {
    }

    public PersonContactDto(string contactName, string data, bool isMainContact, string personContactTypeName)
    {
        ContactName = contactName;
        Data = data;
        IsMainContact = isMainContact;
        PersonContactTypeName = personContactTypeName;
    }

    public string ContactName { get; }
    public string Data { get; }
    public bool IsMainContact { get; }
    public string PersonContactTypeName { get; }
}