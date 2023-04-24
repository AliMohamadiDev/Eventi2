using Eventi.Domain.OrderAgg;

namespace Eventi.Domain.EventAgg;

public class Ticket
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public int Number { get; private set; }
    public int UsedNumber { get; private set; }
    public double Price { get; set; }
    public double TotalPrice { get; private set; }
    public float DiscountRate { get; private set; }
    public string? Description { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public long EventId { get; private set; }
    public Event Event { get; private set; }
    //public List<AccountTicket> AccountTickets { get; private set; } = new();
    public bool IsDeactived { get; private set; }
    public List<DiscountCode> DiscountCodes { get; private set; } = new();
    public List<Order> Orders { get; private set; } = new();


    protected Ticket()
    {
    }

    public Ticket(string title, string? description, int number, double price, DateTime startTime, DateTime endTime, long eventId, double totalPrice, float discountRate)
    {
        Title = title;
        Description = description;
        Number = number;
        Price = price;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
        TotalPrice = totalPrice;
        DiscountRate = discountRate;
        IsDeactived = false;
        UsedNumber = 0;
    }


    public void Edit(string title, string? description, int number, double price, DateTime startTime, DateTime endTime, long eventId, double totalPrice, float discountRate)
    {
        Title = title;
        Description = description;
        Number = number;
        Price = price;
        StartTime = startTime;
        EndTime = endTime;
        EventId = eventId;
        TotalPrice = totalPrice;
        DiscountRate = discountRate;
    }

    public void Deactivate()
    {
        IsDeactived = true;
    }

    public void Activate()
    {
        IsDeactived = false;
    }

    public void IncreaseUsed()
    {
        UsedNumber++;
    }
}