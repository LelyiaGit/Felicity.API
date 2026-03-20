using Felicity.Domain.Employments.Models;
using Felicity.Domain.Employments.Services.Interfaces;
using Felicity.Repository.Employment.Repositories.Interfaces;

namespace Felicity.Domain.Employments.Services.Implementations;

internal class EmploymentService : IEmploymentService
{
    private readonly IEmploymentRepository employmentRepository;

    public EmploymentService(IEmploymentRepository employmentRepository)
    {
        this.employmentRepository = employmentRepository;
    }

    public async Task<IEnumerable<EmploymentModel>> GetEmployments()
    {
        var entities = await this.employmentRepository.GetEmployments();
        return entities.Select(e => new EmploymentModel
        {
            Id = e.Id,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            PersonId = e.PersonId
        });
    }
}
