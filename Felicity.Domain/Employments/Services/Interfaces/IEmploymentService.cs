using Felicity.Domain.Employments.Models;

namespace Felicity.Domain.Employments.Services.Interfaces;

public interface IEmploymentService
{
    Task<IEnumerable<EmploymentModel>> GetEmployments(Guid personId);
    Task<EmploymentModel?> GetEmployment(Guid id);
    Task<EmploymentModel?> PostEmployment(Guid personId, EmploymentPostModel postModel);
}
