using Microsoft.AspNetCore.Mvc;
using TaksunPars.Application.DTOs;
using TaksunPars.Application.Services;

namespace ERP.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthServices authServices, ILogger<AuthController> logger)
    {
        _authServices = authServices;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (dto == null)
            return BadRequest(new { Message = "Request body cannot be null." });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var token = await _authServices.LoginAsync(dto.Username, dto.Password);

        if (string.IsNullOrEmpty(token))
        {
            _logger.LogWarning("Failed login attempt for username: {username}", dto.Username);
            return Unauthorized(new { Message = "Invalid username or password." });
        }


        return Ok(new { Token = token });
    }
}