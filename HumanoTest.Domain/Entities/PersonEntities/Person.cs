namespace HumanoTest.Domain.Entities.PersonEntities;

public partial class Person : EntityBase
{
    public Person(int id) : base(id)
    {
    }

    public Person(string identityNumber, string name, int age)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    public Person(int id, string identityNumber, string name, int age) : base(id)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    public string IdentityNumber { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public IEnumerable<PersonContact> Contacts { get; set; }
}