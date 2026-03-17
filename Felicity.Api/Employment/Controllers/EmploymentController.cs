using Felicity.Domain.Employments.Services.Interfaces;
using Felicity.Domain.Employments.Models;
using Microsoft.AspNetCore.Mvc;

namespace Felicity.Api.Employment.Controllers;

[ApiController]
[Route("employments")]
public class EmploymentController : Controller
{
    private readonly IEmploymentService employmentService;

    public EmploymentController(IEmploymentService employmentService)
    {
        this.employmentService = employmentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IEnumerable<EmploymentModel>> GetEmployments()
    {
        return await this.employmentService.GetEmployments();
    }
}
