using Shared.Enums;
using Shared.Interfaces;

namespace HumanResources.Application.Conversions;

public class GenderTypeConverter : IEntityValueConverter
{
    public object? DtoToEntity(object? dtoValue)
    {
        return dtoValue is string s
            ? Conversions.String2GenderType(s)
            : null;
    }

    public object? EntityToDto(object? entityValue)
    {
        return entityValue is GenderType g
            ? Conversions.GenderType2String(g)
            : null;
    }
}
