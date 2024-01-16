namespace HumanoTest.Application.Services.Person;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Contracts.IServices.Person;
using HumanoTest.Application.Models.Person;
using HumanoTest.Domain.Contracts.IRepositories.Person;
using System.Threading.Tasks;
using Domain.Entities.Person;

public class PersonService : IPersonService
{
    private readonly IPersonRepository personRepository;
    private readonly IPersonContactRepository personContactRepository;

    public PersonService(IPersonRepository PersonRepository, IPersonContactRepository PersonContactRepository)
    {
        personRepository = PersonRepository;
        personContactRepository = PersonContactRepository;
    }

    public async Task<ResponseData> CreateAsync(PersonCreateDto personCreateDto)
    {
        Person person = new(personCreateDto.IdentityNumber, personCreateDto.Name, personCreateDto.Age);

        List<PersonContact> personContacts = new();

        if (personCreateDto.Contacts != null)
        {
            foreach( PersonContactCreateDto contact in personCreateDto.Contacts)
            {
                personContacts.Add(new PersonContact(contact.PersonContactTypeId, contact.ContactName, contact.Data, person, contact.IsMainContact));
            }
            
            var data = await personContactRepository.AddRangeAsync(personContacts);

            return data;
        }

        return await personRepository.CreateAsync(person);
    }

    public async Task<ResponseData> GetAllAsync(int page, int take)
    {
        return await personRepository.GetAllDataAsync(page, take,
          select: x => new PersonDto(x.Id, x.IdentityNumber, x.Name, x.Age,
          x.Contacts.Select(x => new PersonContactDto(x.ContactName, x.Data, x.IsMainContact, x.PersonContactType.Name))));
    }

    public async Task<ResponseData> GetByIdentityNumberId(int page, int take, int identityNumberId)
    {
        return await personRepository.GetAllDataAsync(page, take,
            select: x => new PersonDto(x.Id, x.IdentityNumber, x.Name, x.Age,
            x.Contacts.Select(x => new PersonContactDto(x.ContactName, x.Data, x.IsMainContact, x.PersonContactType.Name))),
            whereCondition: x => x.IdentityNumber == identityNumberId);
    }
}