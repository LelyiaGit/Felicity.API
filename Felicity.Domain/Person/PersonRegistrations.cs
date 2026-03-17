using Felicity.Domain.Person.Services.Implementations;
using Felicity.Domain.Person.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain.Person;

internal static class PersonRegistrations
{
    public static IServiceCollection RegisterPersonDomain(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        return services;
    }
}
