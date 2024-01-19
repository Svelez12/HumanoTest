namespace HumanoTest.Domain.Entities.PersonEntities;

public partial class PersonContactType : EntityBase
{
    /// <summary>
    /// Create a Resource.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public PersonContactType(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Edits a Resource.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public PersonContactType(int id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }

    public string Description { get; set; }
}