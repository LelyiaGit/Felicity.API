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
            .MustAsync(IdMustBeUnique)
                .WithMessage("A person with the same Id already exists.");
    }

    private async Task<bool> IdMustBeUnique(Guid id, CancellationToken cancellationToken)
    {
        var existing = await this.personRepository.GetPerson(id);
        return existing == null;
    }
}