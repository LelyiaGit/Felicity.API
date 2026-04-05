using Felicity.Domain.Person.Models;
using Felicity.Repository.Person.Repositories.Interfaces;
using FluentValidation;

namespace Felicity.Domain.Person.Validators;

internal class PersonPostModelValidator : AbstractValidator<PersonPostModel>
{
    private readonly IPersonRepository personRepository;

    public PersonPostModelValidator(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;

        RuleFor(obj => obj.Id)
            .Must(BeValidGuid)
                .WithMessage("Id must be a valid GUID.")
            .MustAsync(IdMustBeUnique)
                .WithMessage("A person with the same Id already exists.");

        RuleFor(obj => obj.Name)
            .NotEmpty()
                .WithMessage("Name is required.");
    }

    private bool BeValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }

    private async Task<bool> IdMustBeUnique(Guid id, CancellationToken ct)
    {
        var existing = await this.personRepository.GetPerson(id, ct);
        return existing == null;
    }
}