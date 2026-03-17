using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Person.Entities;

public class PersonEntity
{
    public Guid Id { get; set; }
    public int CitizenNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<EmploymentEntity> Employments { get; set; } = new List<EmploymentEntity>();
}
