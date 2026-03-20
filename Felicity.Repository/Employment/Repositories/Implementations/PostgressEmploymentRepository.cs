using Felicity.Repository.Employment.Entities;
using Felicity.Repository.Employment.Repositories.Interfaces;

namespace Felicity.Repository.Employment.Repositories.Implementations;

internal class PostgressEmploymentRepository : IEmploymentRepository
{
    private readonly FelicityContext _db;

    public PostgressEmploymentRepository(FelicityContext db)
    {
        _db = db;
    }

    public Task<IEnumerable<EmploymentEntity>> GetEmployments()
    {
        var employments = new List<EmploymentEntity>
        {
        };

        return Task.FromResult<IEnumerable<EmploymentEntity>>(employments);
    }
}
