using Microsoft.EntityFrameworkCore;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.Employment.Entities;

namespace Felicity.Repository.Data;

public class FelicityDbContext : DbContext
{
    public FelicityDbContext(DbContextOptions<FelicityDbContext> options) : base(options)
    {
    }

    public DbSet<PersonEntity> Persons { get; set; } = null!;
    public DbSet<EmploymentEntity> Employments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonEntity>(entity =>
        {
            entity.ToTable("persons");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CitizenNumber);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.HasMany(e => e.Employments)
                  .WithOne(e => e.Person)
                  .HasForeignKey(e => e.PersonId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EmploymentEntity>(entity =>
        {
            entity.ToTable("employments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompanyName).HasMaxLength(300);
            entity.Property(e => e.Position).HasMaxLength(200);
        });

        base.OnModelCreating(modelBuilder);
    }
}
