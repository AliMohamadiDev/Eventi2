using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class IndexModel : PageModel
{
    [TempData] public string LoginMessage { get; set; }
    [TempData] public string RegisterMessage { get; set; }

    public List<EventQueryModel> UpcomingEvents;
    public List<EventQueryModel> PassedEvents;
    public List<DepartmentQueryModel> Departments;
    public List<SlideQueryModel> Slides;

    private readonly IEventQuery _eventQuery;
    private readonly IDepartmentQuery _departmentQuery;
    private readonly ISlideQuery _slideQuery;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IEventQuery eventQuery, IDepartmentQuery departmentQuery, ISlideQuery slideQuery)
    {
        _logger = logger;
        _eventQuery = eventQuery;
        _departmentQuery = departmentQuery;
        _slideQuery = slideQuery;
    }

    public async Task OnGetAsync()
    {
        UpcomingEvents = await _eventQuery.GetLatestEventsAsync(6, isUpcoming: true, isPassed: false);
        PassedEvents = await _eventQuery.GetLatestEventsAsync(6, isUpcoming: false, isPassed: true);
        Departments = await _departmentQuery.GetDepartmentsAsync(4);
        Slides = await _slideQuery.GetSlidesAsync();
    }
}