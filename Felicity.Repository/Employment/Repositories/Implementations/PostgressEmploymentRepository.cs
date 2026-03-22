using Felicity.Repository.Employment.Entities;
using Felicity.Repository.Employment.Repositories.Interfaces;
using Felicity.Repository.Person.Entities;
using Microsoft.EntityFrameworkCore;

namespace Felicity.Repository.Employment.Repositories.Implementations;

internal class PostgressEmploymentRepository : IEmploymentRepository
{
    private readonly FelicityContext _db;

    public PostgressEmploymentRepository(FelicityContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<EmploymentEntity>> GetEmployments(CancellationToken ct)
    {
        return await _db.Employments
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<EmploymentEntity?> GetEmployment(Guid id, CancellationToken ct)
    {
        return await _db.Employments
          .AsNoTracking()
          .SingleOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<EmploymentEntity?> PostEmployment(EmploymentEntity employment, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(employment);

        _db.Employments.Add(employment);
        await _db.SaveChangesAsync(ct);

        return employment;
    }
}
