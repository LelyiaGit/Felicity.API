using System;

namespace Felicity.Domain.Employments.Models;

public class EmploymentModel
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid PersonId { get; set; }
}
