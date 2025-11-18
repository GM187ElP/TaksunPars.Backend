namespace TaksunPars.Core.Entities;

public class PaySlip
{
    public Guid Id { get; set; }
    public Guid PersonnelId { get; set; }
    public DateTime PayDate { get; set; }
    public decimal Amount { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public Personnel Personnel { get; set; }
}