namespace HumanResources.Application.DTOs;

public interface IEntityValueConverter
{
    object? DtoToEntity(object? dtoValue);
    object? EntityToDto(object? entityValue);
}
