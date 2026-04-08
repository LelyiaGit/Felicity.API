namespace Felicity.Domain.Person.Models;

public abstract class PersonBaseModel
{
    public int? CitizenNumber { get; set; }
    public string Name { get; set; } = string.Empty;
}
