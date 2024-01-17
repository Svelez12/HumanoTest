namespace HumanoTest.Api.Tests.Services;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Models.Person;
using HumanoTest.Domain.Contracts.IRepositories.Person;
using HumanoTest.Domain.Entities.Person;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

public class Tests
{
    protected TestServer server;
    private IPersonRepository personRepository;

    [SetUp]
    public void Setup()
    {
        server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        personRepository = server.Host.Services.GetService<IPersonRepository>();
    }

    [Test]
    public async Task CreateAsync()
    {
        Person person = new(11, 1234588, "Maria Trinidad", 10);

        ResponseData responseData = await personRepository.CreateAsync(person);

        if (!responseData.Success)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }

    [Test]
    public async Task GetAllDataAsync()
    {
        ResponseData responseData = await personRepository.GetAllDataAsync(1, 10, x => new
        PersonDto(x.Id, x.IdentityNumber, x.Name, x.Age,
        x.Contacts.Select(x =>
        new PersonContactDto(x.ContactName, x.Data, x.IsMainContact, x.PersonContactType.Name)
        )));

        if (!responseData.Success)
        {
            Assert.Fail();
        }

        Assert.Pass();
    }
}