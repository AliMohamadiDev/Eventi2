using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.Presenter;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class PresenterModel : PageModel
{
    public PresenterQueryModel Presenter;
    public List<EventQueryModel> Events;

    private readonly IEventQuery _eventQuery;
    private readonly IPresenterQuery _presenterQuery;

    public PresenterModel(IEventQuery eventQuery, IPresenterQuery presenterQuery)
    {
        _eventQuery = eventQuery;
        _presenterQuery = presenterQuery;
    }

    public async Task OnGetAsync(string id)
    {
        Presenter = await _presenterQuery.GetPresenterAsync(id);
        Events = await _eventQuery.GetEventsByPresenterAsync(id);
    }
}