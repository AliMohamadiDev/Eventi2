using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Order;
using Eventi.Domain.OrderAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
{
    private readonly EventiContext _context;

    public OrderRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public Order GetOrder(long id)
    {
        throw new NotImplementedException();
    }

    public double GetAmountBy(long id)
    {
        var order = _context.Orders.Select(x => new { x.PayAmount, x.Id }).FirstOrDefault(x => x.Id == id);
        if (order != null)
            return order.PayAmount;

        return 0;
    }

    public async Task<List<OrderViewModel>> SearchAsync(OrderSearchModel searchModel)
    {
        var account = await _context.Accounts.Select(x => new { x.Id, x.Fullname }).ToListAsync();
        var query = _context.Orders.Select(x => new OrderViewModel
        {
            Id = x.Id,
            AccountId = x.AccountId,
            DiscountAmount = x.DiscountAmount,
            PayAmount = x.PayAmount,
            IsCanceled = x.IsCanceled,
            IsPaid = x.IsPaid,
            IssueTrackingNo = x.IssueTrackingNo,
            RefId = x.RefId,
            CreationDate = x.CreationDate.ToShortDateString(),
            TicketId = x.TicketId,
            Ticket = x.Ticket.Title
        });

        query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);

        if (searchModel.AccountId > 0)
        {
            query = query.Where(x => x.AccountId == searchModel.AccountId);
        }

        var orders = await query.OrderByDescending(x => x.Id).ToListAsync();

        foreach (var order in orders)
        {
            order.AccountFullname = account.FirstOrDefault(x => x.Id == order.AccountId)!.Fullname;
        }

        return orders;
    }
}