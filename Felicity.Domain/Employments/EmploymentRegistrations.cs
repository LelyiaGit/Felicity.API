using Felicity.Domain.Employments.Services.Implementations;
using Felicity.Domain.Employments.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain.Employments;

internal static class EmploymentRegistrations
{
    public static void RegisterEmploymentDomain(this IServiceCollection services)
    {
        services.AddScoped<IEmploymentService, EmploymentService>();
    }
}
