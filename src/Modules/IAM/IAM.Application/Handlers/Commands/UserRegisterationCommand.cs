using IAM.Application.DTOs;
using MediatR;
using Shared;

namespace IAM.Application.Handlers.Commands;

public record UserRegisterationCommand(UserRegistrationDto Dto) : IRequest<ResultStatus>;
