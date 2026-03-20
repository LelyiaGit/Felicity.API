using Microsoft.AspNetCore.Mvc;

namespace Felicity.Api.HealthChecks.Controllers;


[ApiController]
[Route("health")]
public class HealthChecksController : Controller
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}