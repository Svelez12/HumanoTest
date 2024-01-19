namespace HumanoTest.Infrastructure.EntitiesConfig.Person;

using HumanoTest.Domain.Entities.PersonEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonContactTypeConfig
{
    public static void SetEntityBuilderSQLServer(EntityTypeBuilder<PersonContactType> entityBuilder)
    {
        entityBuilder.HasComment("Entidad de Información de Tipo de Contacto Persona.");
        entityBuilder.HasKey(eb => eb.Id);
        entityBuilder.Property(eb => eb.Id).IsRequired().ValueGeneratedOnAdd().HasColumnOrder(1).HasComment("Identificador Único de Entidad.");
        entityBuilder.Property(eb => eb.Name).IsRequired().HasMaxLength(100).HasColumnOrder(2).HasComment("Nombre.");
        entityBuilder.HasIndex(eb => eb.Name).IsUnique();
        entityBuilder.Property(eb => eb.Description).HasMaxLength(600).HasColumnOrder(3).HasComment("Descripcion.");

        List<PersonContactType> personContactTypes = new();

        for (var i = 1; i < 10; i++)
        {
            personContactTypes.Add(
                new PersonContactType(id: i,
                                      name: $"Contact Type {i}",
                                      description: $"Description Of Contact Type {i}"));
        }

        entityBuilder.HasData(personContactTypes);
    }
}