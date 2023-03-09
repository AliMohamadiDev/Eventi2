using _01_EventiQuery.Contracts.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public List<EventQueryModel> Events;

        private readonly IEventQuery _eventQuery;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IEventQuery eventQuery)
        {
            _logger = logger;
            _eventQuery = eventQuery;
        }

        public async Task OnGetAsync()
        {
            Events = await _eventQuery.GetLatestEventsAsync();
        }
    }
}