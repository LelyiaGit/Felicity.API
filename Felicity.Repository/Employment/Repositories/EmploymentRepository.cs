using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Employment.Repositories;

internal class EmploymentRepository : IEmploymentRepository
{
    public Task<IEnumerable<EmploymentEntity>> GetEmployments()
    {
        var employments = new List<EmploymentEntity>
        {
            new() {
                Id = Guid.NewGuid(),
                CompanyName = "Acme Corp",
                Position = "Software Engineer",
                StartDate = new DateTime(2020, 1, 15)
            },
            new() {
                Id = Guid.NewGuid(),
                CompanyName = "Widget Co",
                Position = "Senior Developer",
                StartDate = new DateTime(2022, 6, 1)
            }
        };

        return Task.FromResult<IEnumerable<EmploymentEntity>>(employments);
    }
}
