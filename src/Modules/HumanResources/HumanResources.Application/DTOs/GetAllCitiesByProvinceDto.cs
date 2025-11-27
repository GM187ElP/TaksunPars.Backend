using Shared;

namespace HumanResources.Application.DTOs;

public class GetAllCitiesByProvinceDto
{
    [EntityInfo("Id")]
    public Guid Id { get; set; }
    [EntityInfo("Name")]
    public string Name { get; set; } = string.Empty;
    [EntityInfo("IsCapital")]
    public bool IsCapital { get; set; }
}


