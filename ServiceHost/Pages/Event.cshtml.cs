using _0_Framework.Application;
using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.Presenter;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class EventModel : PageModel
{
    public EventQueryModel Event;
    public TicketQueryModel Ticket;
    public DepartmentQueryModel Department;
    public List<PresenterQueryModel> Presenters;
    public bool IsOwned;

    private readonly IAuthHelper _authHelper;
    private readonly IEventQuery _eventQuery;
    private readonly IDepartmentQuery _departmentQuery;


    public EventModel(IEventQuery eventQuery, IAuthHelper authHelper, IDepartmentQuery departmentQuery)
    {
        _authHelper = authHelper;
        _eventQuery = eventQuery;
        _departmentQuery = departmentQuery;
    }

    public async Task OnGetAsync(string id)
    {
        Event = await _eventQuery.GetEventDetailsAsync(id);
        Department = await _departmentQuery.GetDepartmentAsync(Event.DepartmentSlug);
        Presenters = Event.Presenters;

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