using HumanResources.Application.Conversions;
using HumanResources.Application.DTOs;
using HumanResources.Application.Interfaces;
using MediatR;
using Shared;
using Shared.Conversions;

namespace HumanResources.Application.Handlers.Queries.Department;

public class GetAllDepartmentsAsyncQueryHandler : IRequestHandler<GetAllDepartmentsAsyncQuery, ResultData<List<GetAllDepartmentsDto>>>
{
    private readonly IDepartmentRepository _repo;

    public GetAllDepartmentsAsyncQueryHandler(IDepartmentRepository repo)
    {
        _repo = repo;
    }

    public async Task<ResultData<List<GetAllDepartmentsDto>>> Handle(GetAllDepartmentsAsyncQuery request, CancellationToken cancellationToken)
    {
        var result = new ResultData<List<GetAllDepartmentsDto>>();
        var depertments = await _repo.GetAllDepartmentsAsync();
        var dtoList = new List<GetAllDepartmentsDto>();

        foreach (var department in depertments.Data)
        {
            var dto = new GetAllDepartmentsDto();
            Convertor.ProcessEntity2Dto(department, dto);
            dtoList.Add(dto);
        }

        result.Data = dtoList;

        return result;
    }
}
