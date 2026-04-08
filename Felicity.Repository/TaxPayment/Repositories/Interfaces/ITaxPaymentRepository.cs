using Felicity.Repository.TaxPayment.Entities;

namespace Felicity.Repository.TaxPayment.Repositories.Interfaces;

public interface ITaxPaymentRepository
{
    Task<IEnumerable<TaxPaymentEntity>> GetTaxPayments(Guid personId, CancellationToken ct);
    Task<TaxPaymentEntity?> GetTaxPayment(Guid id, CancellationToken ct);
    Task<TaxPaymentEntity?> PostTaxPayment(TaxPaymentEntity entity, CancellationToken ct);
    Task DeleteTaxPayment(Guid id, CancellationToken ct);
}
