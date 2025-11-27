using HumanResources.Domain.Enums;

namespace HumanResources.Application.DTOs.Conversions;

public class WorkingStatusTypeConverter : IEntityValueConverter
{
    public object? DtoToEntity(object? dtoValue)
    {
        return dtoValue is string s
            ? Conversions.String2WorkingStatus(s)
            : null;
    }

    public object? EntityToDto(object? entityValue)
    {
        return entityValue is WorkingStatusType w
            ? Conversions.WorkingStatus2String(w)
            : null;
    }
}
