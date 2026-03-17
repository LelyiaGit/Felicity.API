using Felicity.Domain.Person.Models;

namespace Felicity.Domain.Person.Services.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonModel>> GetPersons();
}
