using Felicity.Domain.TaxPayment.Models;

namespace Felicity.Domain.TaxPayment.Services.Interfaces;

public interface ITaxPaymentService
{
    Task<IEnumerable<TaxPaymentModel>> GetTaxPayments(Guid personId);
    Task<TaxPaymentModel?> GetTaxPayment(Guid id);
}
