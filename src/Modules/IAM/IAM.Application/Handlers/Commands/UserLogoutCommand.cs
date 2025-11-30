using MediatR;
using Shared;

namespace IAM.Application.Handlers.Commands;

public record UserLogoutCommand() : IRequest<ResultStatus>;
