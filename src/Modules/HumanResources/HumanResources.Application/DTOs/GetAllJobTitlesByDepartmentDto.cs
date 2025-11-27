using Shared;

namespace HumanResources.Application.DTOs;

public class GetAllJobTitlesByDepartmentDto
{
    [EntityInfo("Id")]
    public Guid Id { get; set; }
    [EntityInfo("Title")]
    public string Title { get; set; } = string.Empty;
}
