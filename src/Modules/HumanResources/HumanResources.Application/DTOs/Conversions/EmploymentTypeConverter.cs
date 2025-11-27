using HumanResources.Application.DTOs;
using HumanResources.Domain.Enums;

namespace HumanResources.Application.DTOs.Conversions;

public class EmploymentTypeConverter : IEntityValueConverter
{
    public object? DtoToEntity(object? dtoValue)
    {
        return dtoValue is string s
            ? Conversions.String2EmploymentType(s)
            : null;
    }

    public object? EntityToDto(object? entityValue)
    {
        return entityValue is EmploymentType e
            ? Conversions.EmploymentType2String(e)
            : null;
    }
}
