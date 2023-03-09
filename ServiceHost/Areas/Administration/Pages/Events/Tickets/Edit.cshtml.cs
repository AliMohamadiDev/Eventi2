using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Tickets
{
    public class EditModel : PageModel
    {
        public EditTicket Command;
        public SelectList Events;

        private readonly ITicketApplication _ticketApplication;
        private readonly IEventApplication _eventApplication;

        public EditModel(ITicketApplication ticketApplication, IEventApplication eventApplication)
        {
            _ticketApplication = ticketApplication;
            _eventApplication = eventApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = await _ticketApplication.GetDetailsAsync(id);
            var events = await _eventApplication.GetEventsAsync();
            Events = new SelectList(events, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(EditTicket command)
        {
            var result = await _ticketApplication.EditTicketAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
