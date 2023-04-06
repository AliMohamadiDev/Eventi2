using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class SearchModel : PageModel
{
    public string Value;
    public List<EventQueryModel> Events;
    private readonly IEventQuery _eventQuery;

    public SearchModel(IEventQuery eventQuery)
    {
        _eventQuery = eventQuery;
    }

    public async Task OnGet(string value)
    {
        Value = value;
        Events = await _eventQuery.SearchAsync(value);
    }
}