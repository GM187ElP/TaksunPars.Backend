using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class City:ISoftDelete
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ProvinceId { get; set; }
    public bool IsCapital { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Province? Province { get; set; }
    public ICollection<Employee> BirthPlaces { get; set; } = [];
    public ICollection<Employee> ShenasnameIssuedPlaces { get; set; } = [];
}
