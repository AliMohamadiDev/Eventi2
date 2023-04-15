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
    public Ticket Ticket { get; private set; }
}