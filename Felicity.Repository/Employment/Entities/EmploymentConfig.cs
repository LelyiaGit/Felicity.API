using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Felicity.Repository.Employment.Entities;

internal class EmploymentConfig : IEntityTypeConfiguration<EmploymentEntity>
{
    public void Configure(EntityTypeBuilder<EmploymentEntity> entity)
    {
        entity.ToTable("employments");
        entity.HasKey(e => e.Id);
    }
}