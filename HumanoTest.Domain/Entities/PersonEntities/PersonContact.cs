namespace HumanoTest.Domain.Entities.PersonEntities;

public partial class PersonContact : EntityBase
{
    public PersonContact()
    {

    }

    public PersonContact(int id, int personContactTypeId, string contactName, string data, int personId, bool isMainContact) : base(id)
    {
        PersonContactTypeId = personContactTypeId;
        ContactName = contactName;
        Data = data;
        PersonId = personId;
        IsMainContact = isMainContact;
    }
    public PersonContact(int personContactTypeId, string contactName, string data, int personId, bool isMainContact)
    {
        PersonContactTypeId = personContactTypeId;
        ContactName = contactName;
        Data = data;
        PersonId = personId;
        IsMainContact = isMainContact;
    }

    public PersonContact(int personContactTypeId, string contactName, string data, Person person, bool isMainContact)
    {
        PersonContactTypeId = personContactTypeId;
        ContactName = contactName;
        Data = data;
        Person = person;
        IsMainContact = isMainContact;
    }

    public int PersonContactTypeId { get; set; }

    public string ContactName { get; set; }

    public string Data { get; set; }

    public int PersonId { get; set; }

    public bool IsMainContact { get; set; }

    public PersonContactType PersonContactType { get; set; }

    public Person Person { get; set; }
}