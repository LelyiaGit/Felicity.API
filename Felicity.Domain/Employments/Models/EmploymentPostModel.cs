namespace Felicity.Domain.Employments.Models;

public class EmploymentPostModel
{
    public string JobTitle { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
