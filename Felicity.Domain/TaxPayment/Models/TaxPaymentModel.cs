namespace Felicity.Domain.TaxPayment.Models;

public class TaxPaymentModel
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}
