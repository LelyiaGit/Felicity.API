using Felicity.Domain.Infrastructure.Classes;
using Felicity.Domain.Person.Models;

namespace Felicity.Domain.Person.Services.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonModel>> GetPersons();
    Task<PersonModel?> GetPerson(Guid id);
    Task<PersonModel?> PostPerson(PersonPostModel postModel);
    Task<PersonModel?> PutPerson(Guid id, PersonPutModel putModel);
    Task<OperationResult<NoResult>> DeletePerson(Guid id);
}
