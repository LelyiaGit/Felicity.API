using Felicity.Repository.Employment.Entities;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.TaxPayment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Felicity.Repository;

public class FelicityContext : DbContext, IFelicityContext
{
    public FelicityContext(DbContextOptions<FelicityContext> options)
        : base(options)
    {
    }

    public DbSet<EmploymentEntity> Employments { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<TaxPaymentEntity> TaxPayments { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfig());
        modelBuilder.ApplyConfiguration(new EmploymentConfig());
        modelBuilder.ApplyConfiguration(new TaxPaymentConfig());

        base.OnModelCreating(modelBuilder);
    }
}
