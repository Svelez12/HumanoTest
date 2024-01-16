namespace HumanoTest.Domain.Entities;

public abstract class EntityBase : IEntityBase
{
    public EntityBase()
    {
    }

    public EntityBase(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}