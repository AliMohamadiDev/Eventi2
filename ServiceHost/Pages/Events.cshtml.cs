using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class EventsModel : PageModel
{
    public List<EventQueryModel> Events;

    private readonly IEventQuery _eventQuery;

    public EventsModel(IEventQuery eventQuery)
    {
        _eventQuery = eventQuery;
    }

    public async Task OnGetAsync()
    {
        Events = await _eventQuery.GetLatestEventsAsync();
    }
}