namespace Eventi.Application.Contract.EventInfo;

public class CreateEventInfo
{
    public bool IsWebinar { get; set; }
    public bool IsPersonalSystem { get; set; }
    public float Length { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public float TotalHours { get; set; }
    public int RoomCapacity { get; set; }
    public string? HostingService { get; set; }
    public string? LoginLink { get; set; }
    public string? Description { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public long EventId { get; set; }
}