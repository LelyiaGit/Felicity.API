using Felicity.Domain.Employments.Models;

namespace Felicity.Domain.Employments.Services.Interfaces;

public interface IEmploymentService
{
    Task<IEnumerable<EmploymentModel>> GetEmployments();
}
