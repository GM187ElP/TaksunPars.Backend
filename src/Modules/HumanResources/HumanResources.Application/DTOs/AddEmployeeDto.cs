using HumanResources.Application.Conversions;
using Shared;

namespace HumanResources.Application.DTOs;

public class AddEmployeeDto
{
    [EntityInfo("EmployeeCode")]
    public string? EmployeeCode { get; set; } = null;
    [EntityInfo("FirstName")]
    public string? FirstName { get; set; } = null;
    [EntityInfo("LastName")]
    public string? LastName { get; set; } = null;
    [EntityInfo("NationalId")]
    public string? NationalId { get; set; } = null;
    [EntityInfo("ContactNumber")]
    public string? ContactNumber { get; set; } = null;

    [EntityInfo("Gender", typeof(GenderTypeConverter))]
    public string? Gender { get; set; }

    [EntityInfo("WorkingStatus", typeof(WorkingStatusTypeConverter))]
    public string? WorkingStatus { get; set; } = null;

    [EntityInfo("FatherName")]
    public string? FatherName { get; set; } = null;
    [EntityInfo("MaritalStatus", typeof(MaritalStatusTypeConverter))]
    public string? MaritalStatus { get; set; } = null;
    [EntityInfo("ChildrenCount")]
    public int? ChildrenCount { get; set; }

    [EntityInfo("ShenasnameNumber")]
    public string? ShenasnameNumber { get; set; } = null;
    [EntityInfo("ShenasnameSerialLetter")]
    public string? ShenasnameSerialLetter { get; set; } = null;
    [EntityInfo("ShenasnameSerie")]
    public string? ShenasnameSerie { get; set; } = null;
    [EntityInfo("ShenasnameSerial")]
    public string? ShenasnameSerial { get; set; } = null;

    [EntityInfo("BirthDate")]
    public DateTime? BirthDate { get; set; } = null;
    [EntityInfo("BirthPlaceId")]
    public string? BirthPlace { get; set; } = null; // fk

    [EntityInfo("ShenasnameIssuedPlaceId")]
    public long? ShenasnameIssuedPlace { get; set; } = null;  // fk

    [EntityInfo("InsurranceCode")]
    public string? InsurranceCode { get; set; } = null;
    [EntityInfo("InsurranceStatus")]
    public string? InsurranceStatus { get; set; } = null;
    [EntityInfo("HasInsurance")]
    public bool? HasInsurance { get; set; } = null;
    [EntityInfo("ExtraInsurranceCount")]
    public int? ExtraInsurranceCount { get; set; } = null;

    [EntityInfo("DepartmentId")]
    public string? Department { get; set; } = null;  // fk
    [EntityInfo("JobTitleId")]
    public string? JobTitle { get; set; } = null;   // fk
    [EntityInfo("EmploymentType", typeof(EmploymentTypeConverter))]
    public string? EmploymentType { get; set; } = null;
    [EntityInfo("StartingDate")]
    public DateTime? StartingDate { get; set; } = null;

    [EntityInfo("LandPhoneNumber")]
    public string? LandPhoneNumber { get; set; } = null;
    [EntityInfo("Address")]
    public string? Address { get; set; } = null;
    [EntityInfo("PostalCode")]
    public string? PostalCode { get; set; } = null;

    [EntityInfo("MostRecentDegree")]
    public string? MostRecentDegree { get; set; } = null;
    [EntityInfo("Major")]
    public string? Major { get; set; } = null;
}