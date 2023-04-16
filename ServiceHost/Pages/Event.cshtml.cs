using _0_Framework.Application;
using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class EventModel : PageModel
{
    public EventQueryModel Event;
    public TicketQueryModel Ticket;
    public bool IsOwned;

    private readonly IEventQuery _eventQuery;
    private readonly IAuthHelper _authHelper;


    public EventModel(IEventQuery eventQuery, IAuthHelper authHelper)
    {
        _eventQuery = eventQuery;
        _authHelper = authHelper;
    }

    public async Task OnGetAsync(string id)
    {
        Event = await _eventQuery.GetEventDetailsAsync(id);

        bool isOwned = false;
        foreach (var ticket in Event.Tickets)
        {
            isOwned = _eventQuery.UserOwned(Event.Id, _authHelper.CurrentAccountId(), ticket.Id);
            if (isOwned)
            {
                Ticket = Event.Tickets.FirstOrDefault(x => x.Id == ticket.Id)!;
                break;
            }
        }

        IsOwned = isOwned;
    }
}