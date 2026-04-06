using Felicity.Domain.Employments.Mappers;
using Felicity.Domain.Employments.Models;
using Felicity.Domain.Employments.Services.Interfaces;
using Felicity.Domain.Infrastructure.Classes;
using Felicity.Repository.Employment.Repositories.Interfaces;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.Person.Repositories.Interfaces;
using FluentValidation;

namespace Felicity.Domain.Employments.Services.Implementations;

internal class EmploymentService : IEmploymentService
{
    private readonly IPersonRepository personRepository;
    private readonly IEmploymentRepository employmentRepository;
    private readonly IValidator<EmploymentPostModel> postValidator;
    private readonly IValidator<EmploymentDeleteModel> deleteValidator;

    public EmploymentService(
        IPersonRepository personRepository,
        IEmploymentRepository employmentRepository,
        IValidator<EmploymentPostModel> postValidator,
        IValidator<EmploymentDeleteModel> deleteValidator)
    {
        this.personRepository = personRepository;
        this.employmentRepository = employmentRepository;
        this.postValidator = postValidator;
        this.deleteValidator = deleteValidator;
    }

    public async Task<IEnumerable<EmploymentModel>> GetEmployments(Guid personId)
    {
        var entities = await this.employmentRepository.GetEmployments(new CancellationToken());
        return EmploymentMapper.ToModels(entities);
    }

    public async Task<EmploymentModel?> GetEmployment(Guid id)
    {
        try
        {
            var e = await this.employmentRepository.GetEmployment(id, new CancellationToken());
            if (e == null)
            {
                return null;
            }

            return EmploymentMapper.ToModel(e);
        }
        catch (InvalidOperationException)
        {
            // Repository may throw InvalidOperationException if multiple records are found
            // Treat this as "not found" / inconsistent data case and return null so controller returns 404.
            return null;
        }
    }

    public async Task<EmploymentModel?> PostEmployment(Guid personId, EmploymentPostModel postModel)
    {
        var person = await this.personRepository.GetPerson(personId, new CancellationToken());
        if (person == null)
        {
            return null;
        }

        var validationResult = await this.postValidator.ValidateAsync(postModel);

        if (!validationResult.IsValid)
        {
            return null;
        }

        var personEntity = EmploymentMapper.ToEntity(postModel, personId);
        var postResult = await this.employmentRepository.PostEmployment(personEntity, new CancellationToken());

        return postResult is null ? null : EmploymentMapper.ToModel(postResult);
    }

    public async Task<OperationResult<NoResult>> DeleteEmployment(Guid personId, Guid employmentId)
    {
        var person = await this.personRepository.GetPerson(personId, new CancellationToken());
        if (person == null)
        {
            var messages = new List<string> { $"Person with Id {personId} not found." };
            return new OperationResult<NoResult> { Messages = messages };
        }

        var validationResult = await this.deleteValidator.ValidateAsync(
            new EmploymentDeleteModel { PersonId = personId, EmploymentId = employmentId });

        if (!validationResult.IsValid)
        {
            var messages = validationResult.Errors.Select(e => e.ErrorMessage);
            return new OperationResult<NoResult> { Messages = messages };
        }

        await this.employmentRepository.DeleteEmployment(employmentId, new CancellationToken());

        return new OperationResult<NoResult>();
    }
}
