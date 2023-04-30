using _01_EventiQuery.Contracts.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages;

public class IndexModel : PageModel
{
    public int AccountsCount;
    public int OrdersCount;
    public int ArticlesCount;
    public int DepartmentsCount;

    private readonly IIndexQuery _indexQuery;

    public IndexModel(IIndexQuery indexQuery)
    {
        _indexQuery = indexQuery;
    }

    public void OnGet()
    {
        AccountsCount = _indexQuery.AccountsCount();
        OrdersCount = _indexQuery.OrdersCount();
        ArticlesCount = _indexQuery.ArticlesCount();
        DepartmentsCount = _indexQuery.DepartmentsCount();
    }
}