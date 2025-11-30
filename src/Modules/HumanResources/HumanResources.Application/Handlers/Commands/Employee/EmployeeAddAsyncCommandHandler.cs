using HumanResources.Application.Conversions;
using HumanResources.Application.Interfaces;
using MediatR;
using Shared;
using Shared.Conversions;

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
