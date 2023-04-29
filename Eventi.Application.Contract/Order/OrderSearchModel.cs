namespace Eventi.Application.Contract.Order;

public class OrderSearchModel
{
    public long AccountId { get; set; }
    public bool IsCanceled { get; set; }
    public bool IsPaid { get; set; }
}