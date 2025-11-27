using HumanResources.Application.DTOs;
using HumanResources.Application.DTOs.Conversions;
using HumanResources.Domain.Interfaces;
using MediatR;
using Shared;

namespace HumanResources.Application.Handlers.Queries.City;


public class GetAllCitiesByProvinceAsyncQueryHandler : IRequestHandler<GetAllCitiesByProvinceAsyncQuery, ResultData<List<GetAllCitiesByProvinceDto>>>
{
    private readonly ICityRepository _repo;

    public GetAllCitiesByProvinceAsyncQueryHandler(ICityRepository repo)
    {
        _repo = repo;
    }

    public async Task<ResultData<List<GetAllCitiesByProvinceDto>>> Handle(GetAllCitiesByProvinceAsyncQuery request, CancellationToken cancellationToken)
    {
        var result = new ResultData<List<GetAllCitiesByProvinceDto>>();
        var provinceCities = await _repo.GetAllCitiesByProvinceAsync(request.provinceId, cancellationToken);

        var dtoList = new List<GetAllCitiesByProvinceDto>();
        foreach (var provinceCity in provinceCities.Data)
        {
            var dto = new GetAllCitiesByProvinceDto();
            Convertor.ProcessEntity2Dto(provinceCity, dto);
            dtoList.Add(dto);
        }

        result.Data = dtoList;

        return result;
    }
}


