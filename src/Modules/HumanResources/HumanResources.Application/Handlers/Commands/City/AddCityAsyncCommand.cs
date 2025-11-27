using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Commands.City;

public record AddCityAsyncCommand(Domain.Entities.City city) : IRequest<ResultStatus>;
