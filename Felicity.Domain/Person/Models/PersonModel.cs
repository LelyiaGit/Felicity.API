using System;

namespace Felicity.Domain.Person.Models;

public class PersonModel
{
    public Guid Id { get; set; }

    public int? CitizenNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public DateTime? DateOfBirth { get; set; }
}
