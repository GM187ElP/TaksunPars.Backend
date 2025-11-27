using HumanResources.Application.DTOs;
using HumanResources.Domain.Enums;

namespace HumanResources.Application.DTOs.Conversions;

public class NoteTypeConverter : IEntityValueConverter
{
    public object? DtoToEntity(object? dtoValue)
    {
        return dtoValue is string s
            ? Conversions.String2MaritalStatusType(s)
            : null;
    }

    public object? EntityToDto(object? entityValue)
    {
        return entityValue is NoteType n
            ? Conversions.NoteType2String(n)
            : null;
    }
}