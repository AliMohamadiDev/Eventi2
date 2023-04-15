using _0_Framework.Application;
using Eventi.Application.Contract.Order;
using Eventi.Domain.EventAgg;
using Eventi.Domain.OrderAgg;

namespace Eventi.Application;

public class OrderApplication : IOrderApplication
{
    private readonly IOrderRepository _orderRepository;
    private readonly IAuthHelper _authHelper;
    private readonly ITicketRepository _ticketRepository;

    public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper, ITicketRepository ticketRepository)
    {
        _orderRepository = orderRepository;
        _authHelper = authHelper;
        _ticketRepository = ticketRepository;
    }

    public async Task Cancel(long id)
    {
        var order = _orderRepository.GetOrder(id);
        order.Cancel();
        await _orderRepository.SaveChangesAsync();
    }

    public double GetAmountBy(long id)
    {
        return _orderRepository.GetAmountBy(id);
    }

    public async Task<long> PlaceOrder(long accountId, long ticketId)
    {
        var currentAccountId = _authHelper.CurrentAccountId();
        var ticket = _ticketRepository.GetTicket(ticketId);
        var discountAmount = ticket.Price * ticket.DiscountRate;
        var order = new Order(currentAccountId, ticketId, discountAmount, ticket.TotalPrice, ticket);

        await _orderRepository.CreateAsync(order);
        await _orderRepository.SaveChangesAsync();
        return order.Id;
    }

    public async Task<string> PaymentSucceeded(long orderId, long refId)
    {
        var order = _orderRepository.GetOrder(orderId);
        order.PaymentSucceeded(refId);
        var issueTrackingNo = CodeGenerator.Generate("S");
        order.SetIssueTrackingNo(issueTrackingNo);

        await _orderRepository.SaveChangesAsync();
        return issueTrackingNo;

    }

    public async Task<List<OrderViewModel>> Search(OrderSearchModel searchModel)
    {
        return await _orderRepository.SearchAsync(searchModel);
    }
}