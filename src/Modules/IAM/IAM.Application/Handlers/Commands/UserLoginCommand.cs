using IAM.Application.DTOs;
using MediatR;
using Shared;

namespace IAM.Application.Handlers.Commands;

public record UserLoginCommand(UserLoginDto Dto) : IRequest<ResultStatus>;
