namespace TaksunPars.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } // NationalId
    public string PasswordHash { get; set; }
    public Guid PersonnelId { get; set; }
    
    public Personnel Personnel { get; set; }
}