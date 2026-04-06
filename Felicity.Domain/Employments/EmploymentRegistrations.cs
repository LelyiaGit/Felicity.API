using Felicity.Domain.Employments.Models;
using Felicity.Domain.Employments.Services.Implementations;
using Felicity.Domain.Employments.Services.Interfaces;
using Felicity.Domain.Employments.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain.Employments;

internal static class EmploymentRegistrations
{
    public static void RegisterEmploymentDomain(this IServiceCollection services)
    {
        services.AddScoped<IEmploymentService, EmploymentService>();
        services.AddScoped<IValidator<EmploymentPostModel>, EmploymentPostModelValidator>();
        services.AddScoped<IValidator<EmploymentDeleteModel>, EmploymentDeleteModelValidator>();
    }
}
