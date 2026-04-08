using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.TaxPayment.Entities;

public class TaxPaymentEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public PersonEntity Person { get; set; } = null!;
}
