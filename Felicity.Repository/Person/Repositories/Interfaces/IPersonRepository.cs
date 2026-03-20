using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.Person.Repositories.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<PersonEntity>> GetPersons();
    Task<PersonEntity?> GetPerson(Guid id);
    Task<PersonEntity?> PostPerson(PersonEntity person);
}