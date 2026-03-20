using Felicity.Domain.Person.Models;
using Felicity.Domain.Person.Services.Implementations;
using Felicity.Domain.Person.Services.Interfaces;
using Felicity.Domain.Person.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain.Person;

internal static class PersonRegistrations
{
    public static IServiceCollection RegisterPersonDomain(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IValidator<PersonPostModel>, PersonPostModelValidator>();

        return services;
    }
}
