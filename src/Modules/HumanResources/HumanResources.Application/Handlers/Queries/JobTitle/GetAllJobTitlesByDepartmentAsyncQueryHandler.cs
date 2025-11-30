using HumanResources.Application.Conversions;
using HumanResources.Application.DTOs;
using HumanResources.Application.Interfaces;
using MediatR;
using Shared;
using Shared.Conversions;

namespace HumanResources.Application.Handlers.Queries.JobTitle;

public class GetAllJobTitlesByDepartmentAsyncQueryHandler : IRequestHandler<GetAllJobTitlesByDepartmentAsyncQuery, ResultData<List<GetAllJobTitlesByDepartmentDto>>>
{
    private readonly IJobTitleRepository _repo;

    public GetAllJobTitlesByDepartmentAsyncQueryHandler(IJobTitleRepository repo)
    {
        _repo = repo;
    }

    public async Task<ResultData<List<GetAllJobTitlesByDepartmentDto>>> Handle(GetAllJobTitlesByDepartmentAsyncQuery request, CancellationToken cancellationToken)
    {
        var result = new ResultData<List<GetAllJobTitlesByDepartmentDto>>();
        var departmentJobTitles = await _repo.GetAllJobTitlesByDepartment(request.Id);
        var dtoList = new List<GetAllJobTitlesByDepartmentDto>();

        foreach (var departmentJobTitle in departmentJobTitles.Data)
        {
            var dto = new GetAllJobTitlesByDepartmentDto();
            Convertor.ProcessEntity2Dto(departmentJobTitle, dto);
            dtoList.Add(dto);
        }

        result.Data = dtoList;

        return result;
    }
}
