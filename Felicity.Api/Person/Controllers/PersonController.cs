using Felicity.Domain.Person.Models;
using Felicity.Domain.Person.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Felicity.Api.Person.Controllers;

[ApiController]
[Route("persons")]
public class PersonController : Controller
{
    private readonly IPersonService personService;

    public PersonController(IPersonService personService) => this.personService = personService;

    [HttpGet]
    [Route("")]
    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        return await this.personService.GetPersons();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetPerson(string id)
    {
        if (!Guid.TryParse(id.Trim(), out var personGuid))
        {
            return BadRequest("Invalid GUID format");
        }

        var person = await this.personService.GetPerson(personGuid);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> PostPerson([FromBody] PersonPostModel model)
    {
        if (model == null)
        {
            return BadRequest();
        }

        var created = await this.personService.PostPerson(model);
        if (created == null)
        {
            // Validation failed or repository couldn't create
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetPerson), new { id = created.Id.ToString() }, created);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> PutPerson(string id, [FromBody] PersonPutModel model)
    {
        if (!Guid.TryParse(id.Trim(), out var personGuid))
        {
            return BadRequest("Invalid GUID format");
        }

        if (model == null)
        {
            return BadRequest();
        }

        var putResult = await this.personService.PutPerson(personGuid, model);

        if (putResult == null)
        {
            return BadRequest();
        }

        return Ok(putResult);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeletePerson(string id)
    {
        if (!Guid.TryParse(id.Trim(), out var personGuid))
        {
            return BadRequest("Invalid GUID format");
        }

        var deleteResult = await this.personService.DeletePerson(personGuid);

        if (deleteResult == null)
        {
            return BadRequest();
        }

        return Ok(deleteResult);
    }
}
