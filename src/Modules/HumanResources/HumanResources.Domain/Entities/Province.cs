using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class Province:ISoftDelete
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<City> Cities { get; set; } = [];
}

