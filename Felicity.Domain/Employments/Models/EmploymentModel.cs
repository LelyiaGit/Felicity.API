namespace Felicity.Domain.Employments.Models;

public class EmploymentModel
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
