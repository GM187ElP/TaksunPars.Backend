using HumanResources.Application.DTOs;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Commands.Employee;

public record EmployeeAddAsyncCommand(AddEmployeeDto employee) : IRequest<ResultStatus>;
