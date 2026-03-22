using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Employment.Repositories.Interfaces;

public interface IEmploymentRepository
{
    Task<IEnumerable<EmploymentEntity>> GetEmployments(CancellationToken ct);
    Task<EmploymentEntity?> GetEmployment(Guid id, CancellationToken ct);
    Task<EmploymentEntity?> PostEmployment(EmploymentEntity employment, CancellationToken ct);
}
