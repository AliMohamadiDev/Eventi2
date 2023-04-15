namespace Eventi.Application.Contract.Order;

public class OrderViewModel
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public string AccountFullname { get; set; }
    public string CreationDate { get; set; }
    public bool IsPaid { get; set; }
    public bool IsCanceled { get; set; }
    public string? IssueTrackingNo { get; set; }
    public long RefId { get; set; }
    public double DiscountAmount { get; set; }
    public double PayAmount { get; set; }
    public long TicketId { get; set; }
    public string Ticket { get; set; }
}