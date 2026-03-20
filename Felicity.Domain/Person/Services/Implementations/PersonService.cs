using Felicity.Domain.Person.Models;
using Felicity.Domain.Person.Services.Interfaces;
using Felicity.Repository.Person.Repositories.Interfaces;
using Felicity.Domain.Person.Mappers;
using FluentValidation;

namespace Felicity.Domain.Person.Services.Implementations;

internal class PersonService : IPersonService
{
    private readonly IPersonRepository personRepository;
    private readonly IValidator<PersonPostModel> postValidator;

    public PersonService(
        IPersonRepository personRepository,
        IValidator<PersonPostModel> postValidator)
    {
        this.personRepository = personRepository;
        this.postValidator = postValidator;
    }

    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        var entities = await this.personRepository.GetPersons();
        return PersonMapper.ToModels(entities); // No-op to trigger file update
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

            return PersonMapper.ToModel(e);
        }
        catch (InvalidOperationException)
        {
            // Repository may throw InvalidOperationException if multiple records are found
            // Treat this as "not found" / inconsistent data case and return null so controller returns 404.
            return null;
        }
    }

    public async Task<PersonModel?> PostPerson(PersonPostModel postModel)
    {
        var validationResult = await this.postValidator.ValidateAsync(postModel);

        if(!validationResult.IsValid)
        {
            return null;
        }

        var personEntity = PersonMapper.ToEntity(postModel);
        var postResult = await this.personRepository.PostPerson(personEntity);

        return postResult is null ? null : PersonMapper.ToModel(postResult);
    }
}
