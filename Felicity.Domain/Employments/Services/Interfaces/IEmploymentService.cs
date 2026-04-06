using Felicity.Domain.Employments.Models;
using Felicity.Domain.Infrastructure.Classes;

namespace Felicity.Domain.Employments.Services.Interfaces;

public interface IEmploymentService
{
    Task<IEnumerable<EmploymentModel>> GetEmployments(Guid personId);
    Task<EmploymentModel?> GetEmployment(Guid id);
    Task<EmploymentModel?> PostEmployment(Guid personId, EmploymentPostModel postModel);
    Task<OperationResult<NoResult>> DeleteEmployment(Guid personId, Guid employmentId);
}
