namespace HumanoTest.Infrastructure.EntitiesConfig.Person;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HumanoTest.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;

public class PersonConfig
{
    public static void SetEntityBuilderSQLServer(EntityTypeBuilder<Person> entityBuilder)
    {
        entityBuilder.HasComment("Persona");
        entityBuilder.HasKey(eb => eb.Id);
        entityBuilder.Property(eb => eb.Id).IsRequired().ValueGeneratedOnAdd().HasColumnOrder(1).HasComment("Identificador Único de Entidad.");
        entityBuilder.Property(eb => eb.IdentityNumber).IsRequired().HasColumnOrder(2).HasComment("Número de Documento de Identidad.");
        entityBuilder.Property(eb => eb.Name).IsRequired().HasMaxLength(100).HasColumnOrder(3).HasComment("Nombre de Persona.");
        entityBuilder.Property(eb => eb.Age).HasColumnOrder(4).HasComment("Edad de Persona.");

        List<Person> people = new();

        for (var i = 1; i < 10; i++)
        {
            int ramdomIdentityNumber = new Random().Next(0, 999999999);

            people.Add(
                new Person(id: i,
                           identityNumber: ramdomIdentityNumber,
                           name: $"Person {i}",
                           age: i));
        }

        entityBuilder.HasData(people);
    }
}