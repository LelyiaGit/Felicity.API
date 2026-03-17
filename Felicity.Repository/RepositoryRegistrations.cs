using Felicity.Repository.Employment.Repositories;
using Felicity.Repository.Person.Repositories.Implementations;
using Felicity.Repository.Person.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Repository;

public static class RepositoryRegistrations
{
    public static void RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, CsvPersonRepository>();
        services.AddScoped<IEmploymentRepository, EmploymentRepository>();
    }
}
