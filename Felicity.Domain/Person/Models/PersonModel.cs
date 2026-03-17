using System;

namespace Felicity.Domain.Person.Models;

public class PersonModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CitzenNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
