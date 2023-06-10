using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public List<EventQueryModel> UpcomingEvents;
        public List<EventQueryModel> PassedEvents;
        public List<DepartmentQueryModel> Departments;

        private readonly IEventQuery _eventQuery;
        private readonly IDepartmentQuery _departmentQuery;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IEventQuery eventQuery, IDepartmentQuery departmentQuery)
        {
            _logger = logger;
            _eventQuery = eventQuery;
            _departmentQuery = departmentQuery;
        }

        public async Task OnGetAsync()
        {
            UpcomingEvents = await _eventQuery.GetLatestEventsAsync(10, isUpcoming: true, isPassed: false);
            PassedEvents = await _eventQuery.GetLatestEventsAsync(10, isUpcoming: false, isPassed: true);
            Departments = await _departmentQuery.GetDepartmentsAsync(10);
        }
    }
}