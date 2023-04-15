using _0_Framework.Domain;
using Eventi.Application.Contract.Order;

namespace Eventi.Domain.OrderAgg;

public interface IOrderRepository : IRepository<long, Order>
{
    Order GetOrder(long id);
    double GetAmountBy(long id);
    Task<List<OrderViewModel>> SearchAsync(OrderSearchModel searchModel);
}