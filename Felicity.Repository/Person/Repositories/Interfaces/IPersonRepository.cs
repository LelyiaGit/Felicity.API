using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.Person.Repositories.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<PersonEntity>> GetPersons(CancellationToken ct);
    Task<PersonEntity?> GetPerson(Guid id, CancellationToken ct);
    Task<PersonEntity?> PostPerson(PersonEntity person, CancellationToken ct);
    Task<PersonEntity?> PutPerson(PersonEntity person, CancellationToken ct);
    Task DeletePerson(Guid id, CancellationToken ct);
}