using HumanResources.Application.DTOs;
using HumanResources.Application.DTOs.Conversions;
using HumanResources.Domain.Interfaces;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.Province;

public class GetAllProvincesAsyncQueryHandler : IRequestHandler<GetAllProvincesAsyncQuery, ResultData<List<GetAllProvincesDto>>>
{
    private readonly IProvinceRepository _repo;
    public async Task<ResultData<List<GetAllProvincesDto>>> Handle(GetAllProvincesAsyncQuery request, CancellationToken cancellationToken)
    {
        var result = new ResultData<List<GetAllProvincesDto>>();
        var provinces =await _repo.GetAllProvincesAsync(cancellationToken);
        var dtoList= new List<GetAllProvincesDto>();

        foreach (var province in provinces.Data)
        {
            var dto = new GetAllProvincesDto();
            Convertor.ProcessEntity2Dto( province,dto);
            dtoList.Add(dto);
        }

        result.Data = dtoList;

        return result;
    }
}
