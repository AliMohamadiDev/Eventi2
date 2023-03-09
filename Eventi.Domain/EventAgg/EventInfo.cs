namespace Eventi.Domain.EventAgg;

public class EventInfo
{
    public long Id { get; private set; }
    public bool IsWebinar { get; private set; } // true = Webinar, False = Seminar
    public bool IsPersonalSystem { get; private set; } // true = Personal system, false = Eventi system
    public float Length { get; private set; }

    public string? State { get; private set; }
    public string? City { get; private set; }
    public string? Address { get; private set; }

    public float TotalHours { get; private set; }
    public int RoomCapacity { get; private set; }

    public string? HostingService { get; private set; }
    public string? LoginLink { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public long EventId { get; private set; }
    public Event Event { get; private set; }


    protected EventInfo()
    {
    }

    public EventInfo(bool isWebinar, bool isPersonalSystem, float length, string? state, string? city, string? address, string? hostingService, string? loginLink, string? description, DateTime startTime, DateTime endTime, long eventId, float totalHours, int roomCapacity)
    {
        IsWebinar = isWebinar;
        IsPersonalSystem = isPersonalSystem;
        Length = length;
        State = state;
        City = city;
        Address = address;
        HostingService = hostingService;
        LoginLink = loginLink;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
        TotalHours = totalHours;
        RoomCapacity = roomCapacity;
    }

    public void Edit(bool isWebinar, bool isPersonalSystem, float length, string? state, string? city, string? address, string? hostingService, string? loginLink, string? description, DateTime startTime, DateTime endTime, long eventId, float totalHours, int roomCapacity)
    {
        IsWebinar = isWebinar;
        IsPersonalSystem = isPersonalSystem;
        Length = length;
        State = state;
        City = city;
        Address = address;
        HostingService = hostingService;
        LoginLink = loginLink;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
        TotalHours = totalHours;
        RoomCapacity = roomCapacity;
    }
}