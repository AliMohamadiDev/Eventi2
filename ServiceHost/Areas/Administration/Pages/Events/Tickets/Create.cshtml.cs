using Eventi.Application.Contract.DiscountCode;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Tickets
{
    public class CreateModel : PageModel
    {
        public CreateTicket Command;
        public SelectList Events;

        private readonly ITicketApplication _ticketApplication;
        private readonly IEventApplication _eventApplication;

        public CreateModel(ITicketApplication ticketApplication, IEventApplication eventApplication)
        {
            _ticketApplication = ticketApplication;
            _eventApplication = eventApplication;
        }

        public async Task OnGet()
        {
            var events = await _eventApplication.GetEventsAsync();
            Events = new SelectList(events, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(CreateTicket command)
        {
            var result = await _ticketApplication.CreateTicketAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
