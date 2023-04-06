using _01_EventiQuery.Contracts.Presenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchPresentersModel : PageModel
{
    public string Value;
    public List<PresenterQueryModel> Presenters;
    private readonly IPresenterQuery _presenterQuery;

    public SearchPresentersModel(IPresenterQuery presenterQuery)
    {
        _presenterQuery = presenterQuery;
    }

    public async Task OnGet(string value)
    {
        Value = value;
        Presenters = await _presenterQuery.SearchAsync(value);
    }
}