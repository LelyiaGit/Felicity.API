using Felicity.Domain.Employments;
using Felicity.Domain.Person;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain;

public static class DomainRegistrations
{
    public static void RegisterDomain(this IServiceCollection services)
    {
        services.RegisterPersonDomain();
        services.RegisterEmploymentDomain();
    }
}
