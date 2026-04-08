using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Felicity.Repository.TaxPayment.Entities;

internal class TaxPaymentConfig : IEntityTypeConfiguration<TaxPaymentEntity>
{
    public void Configure(EntityTypeBuilder<TaxPaymentEntity> entity)
    {
        entity.ToTable("taxpayments");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");

        entity
            .HasOne(e => e.Person)
            .WithMany(p => p.TaxPayments)
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}