using Felicity.Repository.TaxPayment.Entities;
using Felicity.Repository.TaxPayment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Felicity.Repository.TaxPayment.Repositories.Implementations;

internal class PostgressTaxPaymentRepository : ITaxPaymentRepository
{
    private readonly FelicityContext _db;

    public PostgressTaxPaymentRepository(FelicityContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TaxPaymentEntity>> GetTaxPayments(Guid personId, CancellationToken ct)
    {
        return await _db.TaxPayments
            .AsNoTracking()
            .Where(t => t.PersonId == personId)
            .ToListAsync(ct);
    }

    public async Task<TaxPaymentEntity?> GetTaxPayment(Guid id, CancellationToken ct)
    {
        return await _db.TaxPayments
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<TaxPaymentEntity?> PostTaxPayment(TaxPaymentEntity entity, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _db.TaxPayments.Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity;
    }

    public async Task DeleteTaxPayment(Guid id, CancellationToken ct)
    {
        var entityToDelete = _db.TaxPayments.SingleOrDefault(e => e.Id == id);

        if (entityToDelete != null)
        {
            _db.TaxPayments.Remove(entityToDelete);
            await _db.SaveChangesAsync(ct);
        }
    }
}
