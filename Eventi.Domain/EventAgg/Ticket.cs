namespace Eventi.Domain.EventAgg;

public class Ticket
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public int Number { get; private set; }
    public bool IsFree { get; private set; }
    public double Price { get; set; }
    public string? Description { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public long EventId { get; private set; }
    public Event Event { get; private set; }
    public List<AccountTicket> AccountTickets { get; private set; } = new();
    public bool IsDeactived { get; private set; }


    protected Ticket()
    {
    }

    public Ticket(string title, string? description, int number, bool isFree, double price, DateTime startTime, DateTime endTime, long eventId)
    {
        Title = title;
        Description = description;
        Number = number;
        IsFree = isFree;
        Price = price;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
        IsDeactived = false;
    }


    public void Edit(string title, string? description, int number, bool isFree, double price, DateTime startTime, DateTime endTime, long eventId)
    {
        Title = title;
        Description = description;
        Number = number;
        IsFree = isFree;
        Price = price;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
    }

    public void Deactivate()
    {
        IsDeactived = true;
    }

    public void Activate()
    {
        IsDeactived = false;
    }
}