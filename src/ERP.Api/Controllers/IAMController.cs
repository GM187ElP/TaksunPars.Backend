using IAM.Application.DTOs;
using IAM.Application.Handlers.Commands;
using IAM.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IAMController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJWTTokenService _jwtTokenService;

        public IAMController(IMediator mediator, IJWTTokenService jwtTokenService)
        {
            _mediator = mediator;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto model)
        {
            var result =await _mediator.Send(new UserRegisterationCommand(model));
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var result =await _mediator.Send(new UserLoginCommand(model));
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var result = _mediator.Send(new UserLogoutCommand());
        }
    }









}
