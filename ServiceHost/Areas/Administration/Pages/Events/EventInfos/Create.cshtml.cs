using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventInfos
{
    public class CreateModel : PageModel
    {
        public CreateEventInfo Command;
        public SelectList Events;

        private readonly IEventInfoApplication _eventInfoApplication;
        private readonly IEventApplication _eventApplication;

        public CreateModel(IEventInfoApplication eventInfoApplication, IEventApplication eventApplication)
        {
            _eventInfoApplication = eventInfoApplication;
            _eventApplication = eventApplication;
        }

        public async Task OnGet()
        {
            var events = await _eventApplication.GetEventsAsync();
            Events = new SelectList(events, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(CreateEventInfo command)
        {
            var result = await _eventInfoApplication.CreateEventInfo(command);
            return RedirectToPage("./Index");
        }
    }
}
