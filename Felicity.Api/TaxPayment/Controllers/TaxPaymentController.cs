using Felicity.Domain.TaxPayment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Felicity.Api.TaxPayment.Controllers;

[ApiController]
[Route("persons/{personId}/taxpayments")]
public class TaxPaymentController : Controller
{
    private readonly ITaxPaymentService taxPaymentService;

    public TaxPaymentController(ITaxPaymentService taxPaymentService)
    {
        this.taxPaymentService = taxPaymentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetTaxPayments(string personId)
    {
        if (string.IsNullOrWhiteSpace(personId) || !Guid.TryParse(personId.Trim(), out var personGuid))
            return BadRequest("Invalid GUID format");

        var list = await this.taxPaymentService.GetTaxPayments(personGuid);

        return Ok(list);
    }
}
