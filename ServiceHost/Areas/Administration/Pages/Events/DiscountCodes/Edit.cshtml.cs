using Eventi.Application.Contract.DiscountCode;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.DiscountCodes;

public class EditModel : PageModel
{
    public EditDiscountCode Command;
    public SelectList Tickets;

    private readonly IDiscountCodeApplication _discountCodeApplication;
    private readonly ITicketApplication _ticketApplication;

    public EditModel(IDiscountCodeApplication discountCodeApplication, ITicketApplication ticketApplication)
    {
        _discountCodeApplication = discountCodeApplication;
        _ticketApplication = ticketApplication;
    }

    public async Task OnGetAsync(long id)
    {
        Command = (await _discountCodeApplication.GetDetailsAsync(id))!;
        var tickets = await _ticketApplication.GetTicketsAsync();
        Tickets = new SelectList(tickets, "Id", "Title");
    }

    public async Task<IActionResult> OnPostAsync(EditDiscountCode command)
    {
        var result = await _discountCodeApplication.EditDiscountCodeAsync(command);
        return RedirectToPage("./Index");
    }
}