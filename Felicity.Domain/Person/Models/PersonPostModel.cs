namespace Felicity.Domain.Person.Models;

public class PersonPostModel
{
    public Guid Id { get; set; }
    public int? CitizenNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
