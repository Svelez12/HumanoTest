namespace HumanoTest.Infrastructure.EntitiesConfig.Person;

using HumanoTest.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

public class PersonContactConfig
{
    public static void SetEntityBuilderSQLServer(EntityTypeBuilder<PersonContact> entityBuilder)
    {
        entityBuilder.HasComment("Contactos Persona");
        entityBuilder.HasKey(eb => eb.Id);
        entityBuilder.HasIndex(e => e.Id);
        entityBuilder.Property(eb => eb.Id).IsRequired().ValueGeneratedOnAdd().HasColumnOrder(1).HasComment("Identificador Único de Entidad.");
        entityBuilder.Property(eb => eb.PersonContactTypeId).HasColumnType("int").HasColumnOrder(2).HasComment("Tipo Contacto Persona");
        entityBuilder.Property(eb => eb.ContactName).IsRequired().HasMaxLength(100).HasColumnOrder(3).HasComment("Nombre de Contacto.");
        entityBuilder.Property(eb => eb.Data).IsRequired().HasMaxLength(100).HasColumnOrder(4).HasComment("Dato de Contacto");
        entityBuilder.Property(eb => eb.IsMainContact).HasColumnType("bit").HasColumnOrder(5).HasComment("Identifica si es el Contacto Principal del Cliente, True = Activo or False = Inactivo.");
        entityBuilder.Property(eb => eb.PersonId).HasColumnType("int").HasColumnOrder(6).HasComment("Identificador de Persona.");

        List<PersonContact> personContacts = new();

        int ramdom = new Random().Next(0, 999999999);

        string[] ContactsName = { "Juan", "Pedro", "Leticia", "Roberto" };
        Random randomContact = new Random();
        for (var i = 1; i < 10; i++)
        {
            string randomContactName = ContactsName[randomContact.Next(ContactsName.Length)];
            personContacts.Add(
                new PersonContact(id: i,
                                  personContactTypeId: i,
                                  contactName: $"Person {i}",
                                  data: $"Informacion de Contacto {i}",
                                  personId: i,
                                  isMainContact: false));
        }

        entityBuilder.HasData(personContacts);
    }
}