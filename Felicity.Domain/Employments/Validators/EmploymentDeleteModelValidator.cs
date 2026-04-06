using Felicity.Domain.Employments.Models;
using FluentValidation;

namespace Felicity.Domain.Employments.Validators;

internal class EmploymentDeleteModelValidator : AbstractValidator<EmploymentDeleteModel>
{
    public EmploymentDeleteModelValidator()
    {
    }
}
