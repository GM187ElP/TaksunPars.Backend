using HumanResources.Application.DTOs.Conversions;
using HumanResources.Domain.Interfaces;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Commands.Employee;

public class EmployeeAddAsyncCommandHandler : IRequestHandler<EmployeeAddAsyncCommand, ResultStatus>
{
    private readonly IEmployeeRepository _repo;
    public async Task<ResultStatus> Handle(EmployeeAddAsyncCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Employee();
        Convertor.ProcessDto2Entity(request.employee, entity);
        return await _repo.AddAsync(entity, cancellationToken);
    }
}
