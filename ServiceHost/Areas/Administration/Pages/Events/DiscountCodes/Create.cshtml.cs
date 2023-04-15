using Eventi.Application.Contract.DiscountCode;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.DiscountCodes;

public class CreateModel : PageModel
{
    public CreateDiscountCode Command;
    public SelectList Tickets;

    private readonly IDiscountCodeApplication _discountCodeApplication;
    private readonly ITicketApplication _ticketApplication;

    public CreateModel(IDiscountCodeApplication discountCodeApplication, ITicketApplication ticketApplication)
    {
        _discountCodeApplication = discountCodeApplication;
        _ticketApplication = ticketApplication;
    }

    public async Task OnGet()
    {
        var tickets = await _ticketApplication.GetTicketsAsync();
        Tickets = new SelectList(tickets, "Id", "Title");
    }

    public async Task<IActionResult> OnPostAsync(CreateDiscountCode command)
    {
        var result = await _discountCodeApplication.CreateDiscountCodeAsync(command);
        return RedirectToPage("./Index");
    }
}