using Felicity.Domain.Person.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Felicity.Domain.Person.Models;

namespace Felicity.Api.Person.Controllers;

[ApiController]
[Route("persons")]
public class PersonController : Controller
{
    private readonly IPersonService personService;

    public PersonController(IPersonService personService)
    {
        this.personService = personService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        return await this.personService.GetPersons();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetPerson(Guid id)
    {
        var person = await this.personService.GetPerson(id);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }
}
