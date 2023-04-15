namespace Eventi.Application.Contract.DiscountCode;

public class DiscountCodeSearchModel
{
    public long Id { get; set; }
    public float DiscountRate { get; set; }
    public long TicketId { get; set; }
}