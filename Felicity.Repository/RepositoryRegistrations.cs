using Felicity.Repository.Employment.Repositories.Implementations;
using Felicity.Repository.Employment.Repositories.Interfaces;
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
        services.AddDbContext<FelicityContext>(options =>
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(conn);
        });

        services.AddScoped<IPersonRepository, PostgressPersonRepository>();
        services.AddScoped<IEmploymentRepository, PostgressEmploymentRepository>();
    }
}
