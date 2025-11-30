namespace Shared.Interfaces;

public interface IEntityValueConverter
{
    object? DtoToEntity(object? dtoValue);
    object? EntityToDto(object? entityValue);
}
