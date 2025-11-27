using Shared;

namespace HumanResources.Application.DTOs;

public class GetAllProvincesDto
{
    [EntityInfo("Id")]
    public Guid Id { get; set; }
    [EntityInfo("Name")]
    public string Name { get; set; }
}
