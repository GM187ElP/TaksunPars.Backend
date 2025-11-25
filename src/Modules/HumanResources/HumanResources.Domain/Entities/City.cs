using Shared.Interfaces;

namespace HumanResources.Domain.Entities;

public class City:ISoftDelete
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProvinceId { get; set; }
    public bool IsCapital { get; set; }
    public ICollection<Employee> BirthPlaces { get; set; } = [];
    public ICollection<Employee> ShenasnameIssuedPlaces { get; set; } = [];
    public bool IsDeleted { get; set; } = false;

}
