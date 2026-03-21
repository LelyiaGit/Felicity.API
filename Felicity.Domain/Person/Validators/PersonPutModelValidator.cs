using Felicity.Domain.Person.Models;
using FluentValidation;

namespace Felicity.Domain.Person.Validators;

internal class PersonPutModelValidator : AbstractValidator<PersonPutModel>
{
    public PersonPutModelValidator()
    {
        RuleFor(obj => obj.Name)
            .NotEmpty()
                .WithMessage("Your name can't be empty")
            .MaximumLength(100)
                .WithMessage("Your name can't have more than 100 characters");
    }
}
