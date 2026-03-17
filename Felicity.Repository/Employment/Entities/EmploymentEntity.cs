using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.Employment.Entities
{
    public class EmploymentEntity
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public PersonEntity? Person { get; set; }
    }
}
