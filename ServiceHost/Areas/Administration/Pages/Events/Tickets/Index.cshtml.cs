using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Tickets
{
    public class IndexModel : PageModel
    {
        public TicketSearchModel SearchModel;
        public List<TicketViewModel> Tickets;

        private readonly ITicketApplication _ticketApplication;

        public IndexModel(ITicketApplication ticketApplication)
        {
            _ticketApplication = ticketApplication;
        }

        public async Task OnGetAsync(TicketSearchModel searchModel)
        {
            Tickets = await _ticketApplication.SearchAsync(searchModel);
        }
    }
}
