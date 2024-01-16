namespace HumanoTest.Domain.Entities.Person;

public partial class Person : EntityBase
{
    public Person(int identityNumber, string name, int age)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    public Person(int id, int identityNumber, string name, int age) : base(id)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Age = age;
    }

    public int IdentityNumber { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public IEnumerable<PersonContact> Contacts { get; set; }
}