using Felicity.Domain.TaxPayment.Models;
using Repo = Felicity.Repository.TaxPayment.Entities;

namespace Felicity.Domain.TaxPayment.Mappers;

internal static class TaxPaymentMapper
{
    public static TaxPaymentModel ToModel(Repo.TaxPaymentEntity entity)
    {
        if (entity == null) return null!;

        return new TaxPaymentModel
        {
            Id = entity.Id,
            Amount = entity.Amount,
            PaymentDate = DateTime.SpecifyKind(entity.PaymentDate, DateTimeKind.Utc)
        };
    }

    public static IEnumerable<TaxPaymentModel> ToModels(IEnumerable<Repo.TaxPaymentEntity> entities)
        => entities?.Select(ToModel) ?? Enumerable.Empty<TaxPaymentModel>();
}
