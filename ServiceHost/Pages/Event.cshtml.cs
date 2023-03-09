using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class EventModel : PageModel
{
    public EventQueryModel Event;

    private readonly IEventQuery _eventQuery;

    public EventModel(IEventQuery eventQuery)
    {
        _eventQuery = eventQuery;
    }

    public async Task OnGetAsync(string id)
    {
        Event = await _eventQuery.GetEventDetailsAsync(id);
    }
}