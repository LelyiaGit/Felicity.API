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

    public async Task<PersonModel?> GetPerson(Guid id)
    {
        try
        {
            var e = await this.personRepository.GetPerson(id);
            if (e == null)
            {
                return null;
            }

            return new PersonModel
            {
                Id = e.Id,
                CitzenNumber = e.CitizenNumber,
                FirstName = e.FirstName,
                LastName = e.LastName
            };
        }
        catch (InvalidOperationException)
        {
            // Repository may throw InvalidOperationException if multiple records are found
            // Treat this as "not found" / inconsistent data case and return null so controller returns 404.
            return null;
        }
    }
}
