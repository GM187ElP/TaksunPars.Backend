using Shared.Interfaces;
using System.Reflection;

namespace Shared.Conversions;

public class Convertor
{
    public static void ProcessDto2Entity(object entity, object dto)
    {
        var dtoProperties = dto.GetType().GetProperties();

        foreach (var dtoProperty in dtoProperties)
        {
            var attribute = dtoProperty.GetCustomAttribute<EntityInfoAttribute>();
            if (attribute == null)
                continue;

            var entityProperty = entity.GetType().GetProperty(attribute.Name);
            if (entityProperty == null)
                continue;

            var dtoValue = dtoProperty.GetValue(dto);

            if (attribute.ConverterType != null)
            {
                var converter = (IEntityValueConverter)Activator.CreateInstance(attribute.ConverterType)!;
                var converted = converter.DtoToEntity(dtoValue);
                entityProperty.SetValue(entity, converted);
            }
            else
            {
                entityProperty.SetValue(entity, dtoValue);
            }
        }
    }


    public static void ProcessEntity2Dto(object entity, object dto)
    {
        var dtoProperties = dto.GetType().GetProperties();

        foreach (var dtoProperty in dtoProperties)
        {
            var attribute = dtoProperty.GetCustomAttribute<EntityInfoAttribute>();
            if (attribute == null)
                continue;

            var entityProperty = entity.GetType().GetProperty(attribute.Name);
            if (entityProperty == null)
                continue;

            var entityValue = entityProperty.GetValue(entity);

            if (attribute.ConverterType != null)
            {
                var converter = (IEntityValueConverter)Activator.CreateInstance(attribute.ConverterType)!;
                var converted = converter.EntityToDto(entityValue);
                dtoProperty.SetValue(dto, converted);
            }
            else
            {
                dtoProperty.SetValue(dto, entityValue);
            }
        }
    }
}