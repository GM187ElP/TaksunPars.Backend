using HumanResources.Application.DTOs;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.City;

public record GetAllCitiesByProvinceAsyncQuery(Guid provinceId) : IRequest<ResultData<List<GetAllCitiesByProvinceDto>>>;
