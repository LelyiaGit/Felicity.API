using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Employment.Repositories;

public interface IEmploymentRepository
{
    Task<IEnumerable<EmploymentEntity>> GetEmployments();
}
