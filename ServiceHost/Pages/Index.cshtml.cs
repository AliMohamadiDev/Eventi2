using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public List<EventQueryModel> Events;
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
            Events = await _eventQuery.GetLatestEventsAsync(10);
            Departments = await _departmentQuery.GetDepartmentsAsync(10);
        }
    }
}