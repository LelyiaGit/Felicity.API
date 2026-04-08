using Felicity.Domain.TaxPayment.Mappers;
using Felicity.Domain.TaxPayment.Models;
using Felicity.Domain.TaxPayment.Services.Interfaces;
using Felicity.Repository.TaxPayment.Repositories.Interfaces;

namespace Felicity.Domain.TaxPayment.Services.Implementations;

internal class TaxPaymentService : ITaxPaymentService
{
    private readonly ITaxPaymentRepository taxPaymentRepository;

    public TaxPaymentService(ITaxPaymentRepository taxPaymentRepository)
    {
        this.taxPaymentRepository = taxPaymentRepository;
    }

    public async Task<IEnumerable<TaxPaymentModel>> GetTaxPayments(Guid personId)
    {
        var entities = await this.taxPaymentRepository.GetTaxPayments(personId, new CancellationToken());
        return TaxPaymentMapper.ToModels(entities);
    }

    public async Task<TaxPaymentModel?> GetTaxPayment(Guid id)
    {
        var entity = await this.taxPaymentRepository.GetTaxPayment(id, new CancellationToken());
        return entity is null ? null : TaxPaymentMapper.ToModel(entity);
    }
}
