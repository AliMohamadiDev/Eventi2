namespace Eventi.Application.Contract.Ticket;

public class TicketViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Number { get; set; }
    public int UsedNumber { get; set; }
    public double Price { get; set; }
    public double TotalPrice { get; set; }
    public float DiscountRate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public long EventId { get; set; }
    public string Event { get; set; }
}