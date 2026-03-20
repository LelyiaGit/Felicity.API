using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Felicity.Repository.Person.Entities;

internal class PersonConfig : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(EntityTypeBuilder<PersonEntity> entity)
    {
        entity.ToTable("persons");
        entity.HasKey(e => e.Id);
    }
}
