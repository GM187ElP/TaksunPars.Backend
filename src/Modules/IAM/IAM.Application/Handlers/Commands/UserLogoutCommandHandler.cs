using IAM.Application.Interfaces;
using MediatR;
using Shared;

namespace IAM.Application.Handlers.Commands;

public class UserLogoutCommandHandler : IRequestHandler<ResultStatus>
{
    private readonly IUserRepository _repo;

    public UserLoginCommandHandler(IUserRepository repo)
    {
        _repo = repo;
    }
}
