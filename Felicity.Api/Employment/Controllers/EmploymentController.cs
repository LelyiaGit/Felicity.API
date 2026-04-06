using Felicity.Domain.Employments.Models;
using Felicity.Domain.Employments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Felicity.Api.Employment.Controllers;

[ApiController]
[Route("persons/{personId}/employments")]
public class EmploymentController : Controller
{
    private readonly IEmploymentService employmentService;

    public EmploymentController(IEmploymentService employmentService)
    {
        this.employmentService = employmentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetEmployments(string personId)
    {
        if (string.IsNullOrWhiteSpace(personId) || !Guid.TryParse(personId.Trim(), out var personGuid))
            return BadRequest("Invalid GUID format");

        var list = await this.employmentService.GetEmployments(personGuid);
        return Ok(list);
    }

    [HttpGet]
    [Route("{employmentId}")]
    public async Task<IActionResult> GetEmployment(string personId, string employmentId)
    {
        if (string.IsNullOrWhiteSpace(personId) || !Guid.TryParse(personId.Trim(), out var personGuid))
            return BadRequest("Invalid GUID format");

        if (!Guid.TryParse(employmentId.Trim(), out var employmentGuid))
            return BadRequest("Invalid GUID format");
        

        var person = await this.employmentService.GetEmployment(employmentGuid);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> PostEmployment(string personId, [FromBody] EmploymentPostModel model)
    {
        if (string.IsNullOrWhiteSpace(personId) || !Guid.TryParse(personId.Trim(), out var personGuid))
            return BadRequest("Invalid GUID format");

        if (model == null)
        {
            return BadRequest();
        }

        var created = await this.employmentService.PostEmployment(personGuid, model);
        if (created == null)
        {
            // Validation failed or repository couldn't create
            return BadRequest();
        }

        // Provide both route values: personId is part of the controller route and is required
        return CreatedAtAction(nameof(GetEmployment), new { personId = personGuid, id = created.Id }, created);
    }

    [HttpDelete]
    [Route("{employmentId}")]
    public async Task<IActionResult> DeleteEmployment(string personId, string employmentId)
    {
        if (string.IsNullOrWhiteSpace(personId) || !Guid.TryParse(personId.Trim(), out var personGuid))
            return BadRequest("Invalid GUID format");

        if (!Guid.TryParse(employmentId.Trim(), out var employmentGuid))
            return BadRequest("Invalid GUID format");

        var deleted = await this.employmentService.DeleteEmployment(personGuid, employmentGuid);
        if (!deleted.Success)
        {
            return BadRequest();
        }

        return Ok();
    }
}
