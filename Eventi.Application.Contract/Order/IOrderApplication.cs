namespace Eventi.Application.Contract.Order;

public interface IOrderApplication
{
    Task Cancel(long id);
    double GetAmountBy(long id);
    Task<long> PlaceOrder(long accountId, long ticketId);
    Task<string> PaymentSucceeded(long orderId, long refId);
    Task<List<OrderViewModel>> Search(OrderSearchModel searchModel);
}