namespace TaksunPars.Core.Entities;

public class Personnel
{
    public Guid Id { get; set; }
    public string PersonnelCode { get; set; }
    public string NationalId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    
    public User User { get; set; }
}