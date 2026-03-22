using Felicity.Domain.Employments.Models;
using Felicity.Repository.Employment.Repositories.Interfaces;
using FluentValidation;

namespace Felicity.Domain.Employments.Validators;

internal class EmploymentPostModelValidator : AbstractValidator<EmploymentPostModel>
{
    private readonly IEmploymentRepository employmentRepository;

    public EmploymentPostModelValidator(
        IEmploymentRepository employmentRepository)
    {
        this.employmentRepository = employmentRepository;

        RuleFor(obj => obj.Description)
            .NotEmpty()
                .WithMessage("Description may not be empty.")
            .MaximumLength(100)
                .WithMessage("Description may not be more than 100 characters long.");
    }
}