namespace TaksunPars.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; } // NationalId
    public required string PasswordHash { get; set; }
    public Guid PersonnelId { get; set; }
    
    public required Personnel Personnel { get; set; }
}