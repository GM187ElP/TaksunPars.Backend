using HumanResources.Domain.Enums;
using HumanResources.Domain.Interfaces;

namespace HumanResources.Domain.Entities;

public class Employee:ISoftDelete
{
    public Guid Id { get; set; }

    #region Basic Information
    public string? EmployeeCode { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string? NationalId { get; set; } 
    public string? ContactNumber { get; set; }
    public bool IsDeleted { get; set; } = false;
    #endregion

    #region Gender and Status
    public GenderType? GenderDisplay { get; set; }
    public WorkingStatusType? WorkingStatusDisplay { get; set; } 
    #endregion

    #region Family Information
    public string? FatherName { get; set; } 
    public MaritalStatusType? MaritalStatusDisplay { get; set; }
    public int? ChildrenCount { get; set; } 
    #endregion

    #region Identity Information
    public string? ShenasnameNumber { get; set; } 
    public string? ShenasnameSerialLetter { get; set; } 
    public string? ShenasnameSerie { get; set; } 
    public string? ShenasnameSerial { get; set; } 
    #endregion

    #region Birth and Place Information
    public DateTime? BirthDate { get; set; } 
    public Guid BirthPlaceId { get; set; }  // fk
    public City? BirthPlace { get; set; }
    #endregion

    #region Shenasname Issuance Information
    public Guid ShenasnameIssuedPlaceId { get; set; }  // fk
    public City? ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    public string? InsurranceCode { get; set; } 
    public string? InsurranceStatus { get; set; } 
    public bool? HasInsurance { get; set; } 
    public int? ExtraInsurranceCount { get; set; } 
    #endregion

    #region Employment Information
    public Guid JobTitleId { get; set; }   // fk
    public JobTitle? JobTitle { get; set; }
    public EmploymentType? EmploymentTypeDisplay { get; set; }
    public DateTime? StartingDate { get; set; } 
    public DateTime? LeavingDate { get; set; } 
    public Guid? SupervisorId { get; set; }   // null fk
    public Employee? SuperVisor { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];
    #endregion

    #region Contact Information
    public string? InternalContactNumber { get; set; } 
    public string? LandPhoneNumber { get; set; }
    public string? Address { get; set; } 
    public string? PostalCode { get; set; } 
    #endregion

    #region Academic Information
    public string? MostRecentDegree { get; set; } 
    public string? Major { get; set; } 
    #endregion

    #region Collection Properties
    public ICollection<ChequePromissionaryNote> ChequePromissionaryNotes { get; set; } = [];
    public ICollection<TrackJobTitleAndLeaveHistory> TrackJobTitleAndLeaveHistories { get; set; } = [];
    public ICollection<BankAccount> BankAccounts { get; set; } = [];
    #endregion
}
