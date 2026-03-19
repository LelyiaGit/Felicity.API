using Felicity.Repository.Employment.Repositories;
using Felicity.Repository.Person.Repositories.Implementations;
using Felicity.Repository.Person.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Repository;

public static class RepositoryRegistrations
{
    public static void RegisterRepository(this IServiceCollection services, IConfiguration configuration)
    {
        // Avoid depending on the ConfigurationBinder extension method by parsing the value manually
        var useDatabase = false;
        var raw = configuration["Repository:UseDatabase"];
        if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
        {
            useDatabase = parsed;
        }
        if (useDatabase)
        {
            services.AddDbContext<Data.FelicityDbContext>(options =>
            {
                var conn = configuration.GetConnectionString("FelicityPostgres");
                options.UseNpgsql(conn);
            });

            services.AddScoped<IPersonRepository, PostgresPersonRepository>();
        }
        else
        {
            services.AddScoped<IPersonRepository, CsvPersonRepository>();
        }

        services.AddScoped<IEmploymentRepository, EmploymentRepository>();
    }
}
