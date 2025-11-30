namespace ERP.Api.DTOs;

public class DbData
{
    // Local DB
    public string? LocalHost { get; set; }
    public string? LocalUsername { get; set; }
    public string? LocalPassword { get; set; }
    public string? LocalDatabaseDev { get; set; }
    public string? LocalDatabaseProd { get; set; }
                 
    // Neon Cloud? DB
    public string? NeonHostDev { get; set; }
    public string? NeonHostProd { get; set; }
    public string? NeonUsername { get; set; }
    public string? NeonPasswordDev { get; set; }
    public string? NeonPasswordProd { get; set; }
    public string? NeonDatabase { get; set; }
}
