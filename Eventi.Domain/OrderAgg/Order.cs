using Eventi.Domain.EventAgg;

namespace Eventi.Domain.OrderAgg;

public class Order
{
    public long Id { get; private set; }
    public long AccountId { get; private set; }
    public DateTime CreationDate { get; private set; }
    public bool IsPaid { get; private set; }
    public bool IsCanceled { get; private set; }
    public string? IssueTrackingNo { get; private set; }
    public long RefId { get; private set; }
    public double DiscountAmount { get; private set; }
    public double PayAmount { get; private set; }
    public long TicketId { get; private set; }
    public Ticket Ticket { get; private set; }

    protected Order()
    {
    }

    public Order(long accountId, long ticketId, double discountAmount, double payAmount, Ticket ticket)
    {
        AccountId = accountId;
        TicketId = ticketId;
        DiscountAmount = discountAmount;
        PayAmount = payAmount;
        Ticket = ticket;
        IsPaid = false;
        IsCanceled = false;
        CreationDate = DateTime.Now;
        RefId = 0;
    }

    public void PaymentSucceeded(long refId)
    {
        IsPaid = true;
        if (refId != 0)
        {
            RefId = refId;
        }
    }

    public void SetIssueTrackingNo(string number)
    {
        IssueTrackingNo = number;
    }

    public void Cancel()
    {
        IsCanceled = true;
    }
}