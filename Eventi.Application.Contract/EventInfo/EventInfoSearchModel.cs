namespace Eventi.Application.Contract.EventInfo;

public class EventInfoSearchModel
{
    public bool IsWebinar { get; set; }
    public bool IsPersonalSystem { get; set; }
    public long EventId { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}