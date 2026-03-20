namespace Felicity.Domain.Employments.Models;

public class EmploymentModel
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
