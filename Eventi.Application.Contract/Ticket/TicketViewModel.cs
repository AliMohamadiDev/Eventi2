namespace Eventi.Application.Contract.Ticket;

public class TicketViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Number { get; set; }
    public bool IsFree { get; set; }
    public double Price { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public long EventId { get; set; }
    public string Event { get; set; }
}