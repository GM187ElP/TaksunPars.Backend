using Shared.Enums;
using Shared.Interfaces;

namespace HumanResources.Application.Conversions;

public class MaritalStatusTypeConverter : IEntityValueConverter
{
    public object? DtoToEntity(object? dtoValue)
    {
        return dtoValue is string s
            ? Conversions.String2MaritalStatusType(s)
            : null;
    }

    public object? EntityToDto(object? entityValue)
    {
        return entityValue is MaritalStatusType m
            ? Conversions.MaritalStatusType2String(m)
            : null;
    }
}
