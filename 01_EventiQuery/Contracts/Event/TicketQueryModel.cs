namespace _01_EventiQuery.Contracts.Event;

public class TicketQueryModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Number { get; set; }
    public double Price { get; set; }
    public double TotalPrice { get; set; }
    public float DiscountRate { get; set; }
    public string? Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long EventId { get; set; }
}