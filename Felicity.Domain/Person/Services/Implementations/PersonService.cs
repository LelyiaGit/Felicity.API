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
    private readonly IValidator<PersonPutModel> putValidator;

    public PersonService(
        IPersonRepository personRepository,
        IValidator<PersonPostModel> postValidator,
        IValidator<PersonPutModel> putValidator)
    {
        this.personRepository = personRepository;
        this.postValidator = postValidator;
        this.putValidator = putValidator;
    }

    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        var entities = await this.personRepository.GetPersons(new CancellationToken());
        return PersonMapper.ToModels(entities);
    }

    public async Task<PersonModel?> GetPerson(Guid id)
    {
        try
        {
            var e = await this.personRepository.GetPerson(id, new CancellationToken());
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
        var postResult = await this.personRepository.PostPerson(personEntity, new CancellationToken());

        return postResult is null ? null : PersonMapper.ToModel(postResult);
    }

    public async Task<PersonModel?> PutPerson(Guid id, PersonPutModel putModel)
    {
        var existingPerson = await this.personRepository.GetPerson(id, new CancellationToken());
        if (existingPerson == null)
        {
            return null;
        }

        var validationResult = await this.putValidator.ValidateAsync(putModel);
        
        if (!validationResult.IsValid)
        {
            return null;
        }

        var personEntity = PersonMapper.ToEntity(putModel, id);
        var putResult = await this.personRepository.PutPerson(personEntity, new CancellationToken());
        
        return putResult is null ? null : PersonMapper.ToModel(putResult);
    }
}
