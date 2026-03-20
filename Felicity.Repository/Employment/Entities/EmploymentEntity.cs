using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.Employment.Entities
{
    public class EmploymentEntity
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobDescription { get; set; } = string.Empty;

        public PersonEntity Person { get; set; } = null!;
    }
}
