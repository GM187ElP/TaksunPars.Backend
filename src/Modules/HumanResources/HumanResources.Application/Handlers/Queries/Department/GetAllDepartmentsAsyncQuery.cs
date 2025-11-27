using HumanResources.Application.DTOs;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.Department;

public record GetAllDepartmentsAsyncQuery():IRequest<ResultData<List<GetAllDepartmentsDto>>>;
