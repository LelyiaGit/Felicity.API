using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Employment.Repositories.Interfaces;

public interface IEmploymentRepository
{
    Task<IEnumerable<EmploymentEntity>> GetEmployments();
}
