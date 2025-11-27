using HumanResources.Application.DTOs;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.Province;

public record GetAllProvincesAsyncQuery : IRequest<ResultData<List<GetAllProvincesDto>>>;
