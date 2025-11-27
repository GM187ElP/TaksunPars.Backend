using HumanResources.Application.DTOs;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.JobTitle;

public record GetAllJobTitlesByDepartmentAsyncQuery(Guid Id) : IRequest<ResultData<List<GetAllJobTitlesByDepartmentDto>>>;
