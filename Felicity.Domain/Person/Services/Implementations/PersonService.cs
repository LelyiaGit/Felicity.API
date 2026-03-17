using Felicity.Domain.Person.Models;
using Felicity.Domain.Person.Services.Interfaces;
using Felicity.Repository.Person.Repositories.Interfaces;

namespace Felicity.Domain.Person.Services.Implementations;

internal class PersonService : IPersonService
{
    private readonly IPersonRepository personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        var entities = await this.personRepository.GetPersons();
        return entities.Select(e => new PersonModel
        {
            Id = e.Id,
            CitzenNumber = e.CitizenNumber,
            FirstName = e.FirstName,
            LastName = e.LastName
        });
    }
}
