namespace TaksunPars.Shared;

public class Result
{
    public bool IsPartialySuccess { get; set; }
    public List<string> Errors { get; set; } = [];
    public bool IsSuccess => Errors.Count == 0;
}