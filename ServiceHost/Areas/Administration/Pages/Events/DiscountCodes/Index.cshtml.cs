using Eventi.Application.Contract.DiscountCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.DiscountCodes;

public class IndexModel : PageModel
{
    public DiscountCodeSearchModel SearchModel;
    public List<DiscountCodeViewModel> DiscountCodes;

    private readonly IDiscountCodeApplication _discountCodeApplication;

    public IndexModel(IDiscountCodeApplication discountCodeApplication)
    {
        _discountCodeApplication = discountCodeApplication;
    }

    public async Task OnGetAsync(DiscountCodeSearchModel searchModel)
    {
        DiscountCodes = await _discountCodeApplication.SearchAsync(searchModel);
    }
}