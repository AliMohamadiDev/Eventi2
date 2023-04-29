using Eventi.Application.Contract.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Orders;

public class IndexModel : PageModel
{
    public OrderSearchModel SearchModel;
    public List<OrderViewModel> Orders;

    private readonly IOrderApplication _orderApplication;

    public IndexModel(IOrderApplication orderApplication)
    {
        _orderApplication = orderApplication;
    }

    public async Task OnGetAsync(OrderSearchModel searchModel)
    {
        Orders = await _orderApplication.Search(searchModel);
    }
}