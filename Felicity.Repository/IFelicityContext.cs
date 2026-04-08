using Felicity.Repository.Employment.Entities;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.TaxPayment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Felicity.Repository;

internal interface IFelicityContext
{
    public DbSet<EmploymentEntity> Employments { get; set; }
    public DbSet<PersonEntity> Persons { get; set; }
    public DbSet<TaxPaymentEntity> TaxPayments { get; set; }
}
