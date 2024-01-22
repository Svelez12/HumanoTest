namespace HumanoTest.Api.Tests.Services;

using global::Services.Common.Collection;
using HumanoTest.Application.Contracts;
using HumanoTest.Application.Models.Person;
using HumanoTest.Domain.Contracts.UnitsOfWorks;
using HumanoTest.Domain.Entities.PersonEntities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class PersonServiceTest
{
    protected TestServer server;
    private IPersonUnitOfWork personUnitOfWork;

    [SetUp]
    public void Setup()
    {
        server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        personUnitOfWork = server.Host.Services.GetService<IPersonUnitOfWork>();
    }

    [Test]
    public async Task GetAllDataShouldSuccessAsync()
    {
        List<Person> peoples = new()
        {
            new Person(11, "4022342132", "Maria Trinidad", 60),  new Person(12, "4022342132", "Maria Trinidad", 60)
        };

        await personUnitOfWork.PersonRepository.AddRangeAsync(peoples);

        await personUnitOfWork.SaveChangesAsync();

        ResponseData responseData = await personUnitOfWork.PersonRepository.GetAllDataAsync(1, 10, x => new
        PersonDto(x.Id, x.IdentityNumber, x.Name, x.Age,
        x.Contacts.Select(x =>
        new PersonContactDto(x.ContactName, x.Data, x.IsMainContact, x.PersonContactType.Name)
        )));

        DataCollection<PersonDto> personDtos = (DataCollection<PersonDto>)responseData.Data;

        Assert.That(peoples.Count, Is.EqualTo(personDtos.Items.Count()));
    }

    [Test]
    public async Task CreateShouldSuccessAsync()
    {
        Person person = new(11, "4022342132", "Maria Trinidad", 10);

        await personUnitOfWork.PersonRepository.CreateAsync(person);

        ResponseData responseData = await personUnitOfWork.SaveChangesAsync();

        Assert.IsTrue(responseData.Success);
    }

    [Test]
    public async Task DeleteShouldSuccessAsync()
    {
        Person person = await CreatePersonAsync(personUnitOfWork);

        await personUnitOfWork.PersonRepository.DeleteAsync(person);

        ResponseData responseData = await personUnitOfWork.SaveChangesAsync();

        Assert.IsTrue(responseData.Success);
    }

    [Test]
    public async Task UpdateShouldSuccessAsync()
    {
        int modifyingAge = 10;

        Person person = await CreatePersonAsync(personUnitOfWork);

        person.Age = modifyingAge;

        await personUnitOfWork.PersonRepository.UpdateAsync(person);

        ResponseData responseData = await personUnitOfWork.SaveChangesAsync();

        int age = await personUnitOfWork.PersonRepository.GetByIdAsync(person.Id, x => x.Age, null);

        Assert.That(modifyingAge, Is.EqualTo(age));
    }

    private async Task<Person> CreatePersonAsync(IPersonUnitOfWork personUnitOfWork)
    {
        Person person = new(11, "4022342132", "Maria Trinidad", 60);

        await personUnitOfWork.PersonRepository.CreateAsync(person);

        await personUnitOfWork.SaveChangesAsync();

        return person;
    }
}