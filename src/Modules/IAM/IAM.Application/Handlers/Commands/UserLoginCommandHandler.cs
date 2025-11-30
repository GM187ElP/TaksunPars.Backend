using IAM.Application.DTOs;
using IAM.Application.Interfaces;
using Isopoh.Cryptography.Argon2;
using MediatR;
using Microsoft.Extensions.Configuration;
using Shared;

namespace IAM.Application.Handlers.Commands;

public class UserLoginCommandHandler() : IRequestHandler<UserLoginCommand, ResultStatus>
{
    private readonly IUserRepository _repo;
    private readonly IConfiguration _configuration;
    private readonly IJWTTokenService _jwtTokenService;


    public UserLoginCommandHandler(IUserRepository repo, IConfiguration configuration,IJWTTokenService jwtTokenService)
    {
        _repo = repo;
        _configuration = configuration;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<ResultStatus> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var username=request.Dto.Username;
        var result = new ResultStatus();

        var user=await _repo.FindByUsernameAsync(username);
        if (user == null)
        {
            result.Errors.Add("User not found");
            return result;
        }

        var isAuthenticated = Argon2.Verify(user.PasswordHash,request.Dto.Password);
        if (!isAuthenticated)
        {
            result.Errors.Add("User or Password is wrong");
            return result;
        }



    }

}
