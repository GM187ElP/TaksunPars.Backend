using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HumanResources.Application.DTOs;

public class Conversions
{
    private readonly PersianCalendar persian;

    public Conversions()
    {
        persian = new PersianCalendar();
    }

    //public string Gregorian2Shamsi(DateTime gregorianDate, char delimiter='/')
    //{
    //    var day=persian.GetDayOfMonth(gregorianDate);
    //    var month=persian.GetMonth(gregorianDate);
    //    var year=persian.GetYear(gregorianDate);

    //    return $"{year:0000}{delimiter}{month:00}{delimiter}{day:00}{delimiter}";
    //}

    //public DateTime Shamsi2Gregorian(string shamsiDate)
    //{
    //    var delimiter = shamsiDate.Substring(4, 1);
    //    var parts= shamsiDate.Split(delimiter);

    //    if (parts.Length != 3)
    //        return ;

    //    return persian.ToDateTime(parts[0], parts[1], parts[2],0,0,0,0);
    //}

    //private int String2Int(string part)
    //{
    //    if(int.TryParse(part,out int result))
    //    {
            
    //    }
    //}
}
