namespace Eventi.Application.Contract.Ticket;

public class TicketSearchModel
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public double Price { get; set; }
    public double TotalPrice { get; set; }
    public float DiscountRate { get; set; }
    public bool IsFree { get; set; }
    public long EventId { get; set; }
}