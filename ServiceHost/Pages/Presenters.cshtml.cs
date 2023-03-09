using _01_EventiQuery.Contracts.Presenter;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class PresentersModel : PageModel
{
    public List<PresenterQueryModel> Presenters;

    private readonly IPresenterQuery _presenterQuery;

    public PresentersModel(IPresenterQuery presenterQuery)
    {
        _presenterQuery = presenterQuery;
    }

    public async Task OnGetAsync()
    {
        Presenters = await _presenterQuery.GetPresentersAsync();
    }
}