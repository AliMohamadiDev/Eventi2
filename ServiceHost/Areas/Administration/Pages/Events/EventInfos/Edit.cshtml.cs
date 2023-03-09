using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventInfos
{
    public class EditModel : PageModel
    {
        public EditEventInfo Command;
        public SelectList Events;

        private readonly IEventInfoApplication _eventInfoApplication;
        private readonly IEventApplication _eventApplication;

        public EditModel(IEventInfoApplication eventInfoApplication, IEventApplication eventApplication)
        {
            _eventInfoApplication = eventInfoApplication;
            _eventApplication = eventApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = (await _eventInfoApplication.GetDetailsAsync(id))!;
            var events = await _eventApplication.GetEventsAsync();
            Events = new SelectList(events, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(EditEventInfo command)
        {
            var result = await _eventInfoApplication.EditEventInfoAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
