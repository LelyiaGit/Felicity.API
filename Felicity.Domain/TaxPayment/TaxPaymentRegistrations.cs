using Felicity.Domain.TaxPayment.Services.Implementations;
using Felicity.Domain.TaxPayment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Felicity.Domain.TaxPayment;

internal static class TaxPaymentRegistrations
{
    public static void RegisterTaxPaymentDomain(this IServiceCollection services)
    {
        services.AddScoped<ITaxPaymentService, TaxPaymentService>();
    }
}
