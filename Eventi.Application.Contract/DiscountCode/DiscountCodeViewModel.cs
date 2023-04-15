namespace Eventi.Application.Contract.DiscountCode;

public class DiscountCodeViewModel
{
    public long Id { get; set; }
    public string Code { get; set; }
    public float DiscountRate { get; set; }
    public int Count { get; set; }
    public int CountUsed { get; set; }

    public long TicketId { get; set; }
    public string Ticket { get; set; }
}