using Felicity.Repository.Employment.Entities;
using Felicity.Repository.TaxPayment.Entities;

namespace Felicity.Repository.Person.Entities;

public class PersonEntity
{
    public Guid Id { get; set; }
    public int? CitizenNumber { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<EmploymentEntity> Employments { get; set; } = new List<EmploymentEntity>();
    public ICollection<TaxPaymentEntity> TaxPayments { get; set; } = new List<TaxPaymentEntity>();
}
