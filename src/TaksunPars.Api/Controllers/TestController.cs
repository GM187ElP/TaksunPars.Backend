using Microsoft.AspNetCore.Mvc;

namespace TaksunPars.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new { Message = "API is ff" });
    }
}