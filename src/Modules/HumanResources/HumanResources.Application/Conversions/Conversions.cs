using Shared.Enums;

namespace HumanResources.Application.Conversions;

public class Conversions
{
    public static string GenderType2String(GenderType gender)
    {
        return gender switch
        {
            GenderType.Male => "آقا",
            GenderType.Female => "خانم",
            _ => "انتخاب نشده"
        };
    }
    public static GenderType String2GenderType(string? gender)
    {
        return gender switch
        {
            "آقا" => GenderType.Male,
            "خانم" => GenderType.Female,
            _ => GenderType.NotSelected
        };
    }

    public static string WorkingStatus2String(WorkingStatusType WorkingStatus)
    {
        return WorkingStatus switch
        {
            WorkingStatusType.Working => "سر کار",
            WorkingStatusType.Left => "ترک کار",
            _ => "انتخاب نشده"
        };
    }

    public static WorkingStatusType String2WorkingStatus(string? WorkingStatus)
    {
        return WorkingStatus switch
        {
            "سر کار" => WorkingStatusType.Working,
            "ترک کار" => WorkingStatusType.Left,
            _ => WorkingStatusType.NotSelected
        };
    }

    public static string EmploymentType2String(EmploymentType type)
    {
        return type switch
        {
            EmploymentType.Official => "رسمی",
            EmploymentType.Contract => "پیمانی",
            _ => "انتخاب نشده"
        };
    }

    public static EmploymentType String2EmploymentType(string type)
    {
        return type switch
        {
            "رسمی" => EmploymentType.Official,
            "پیمانی" => EmploymentType.Contract,
            _ => EmploymentType.NotSelected
        };
    }

    public static string NoteType2String(NoteType type)
    {
        return type switch
        {
            NoteType.Cheque => "چک",
            NoteType.PromissionaryNote => "سفته",
            _ => "انتخاب نشده"
        };
    }

    public static NoteType String2NoteType(string type)
    {
        return type switch
        {
            "چک" => NoteType.Cheque,
            "سفته" => NoteType.PromissionaryNote,
            _ => NoteType.NotSelected,
        };
    }

    public static MaritalStatusType String2MaritalStatusType(string type)
    {
        return type switch
        {
            "مجرد" => MaritalStatusType.Single,
            "متاهل" => MaritalStatusType.Married,
            "مطلقه" => MaritalStatusType.Divorced,
            _ => MaritalStatusType.NotSelected
        };
    }

    public static string MaritalStatusType2String(MaritalStatusType type)
    {
        return type switch
        {
            MaritalStatusType.Single => "مجرد",
            MaritalStatusType.Married => "متاهل",
            MaritalStatusType.Divorced => "مطلقه",
            _ => "انتخاب نشده"
        };
    }
}
