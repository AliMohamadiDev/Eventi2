namespace Eventi.Domain.EventAgg;

public class DiscountCode
{
    public long Id { get; private set; }
    public string Code { get; private set; }
    public float DiscountRate { get; private set; }
    public int Count { get; private set; }
    public int CountUsed { get; private set; }

    public long TicketId { get; private set; }
    public Ticket Ticket { get; private set; }

    public DiscountCode(string code, float discountRate, int count)
    {
        Code = code;
        DiscountRate = discountRate;
        Count = count;
    }
}