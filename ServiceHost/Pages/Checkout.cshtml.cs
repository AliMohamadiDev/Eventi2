using System.Globalization;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using Eventi.Application.Contract.Order;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.EventAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

[Authorize]
public class CheckoutModel : PageModel
{
    public Ticket Ticket;

    private readonly IAuthHelper _authHelper;
    private readonly ITicketApplication _ticketApplication;
    private readonly ITicketRepository _ticketRepository;
    private readonly IOrderApplication _orderApplication;
    private readonly IZarinPalFactory _zarinPalFactory;

    public CheckoutModel(ITicketApplication ticketApplication, ITicketRepository ticketRepository, IOrderApplication orderApplication, IAuthHelper authHelper, IZarinPalFactory zarinPalFactory)
    {
        _ticketApplication = ticketApplication;
        _ticketRepository = ticketRepository;
        _orderApplication = orderApplication;
        _authHelper = authHelper;
        _zarinPalFactory = zarinPalFactory;
    }

    public void OnGet(long id)
    {
        Ticket = _ticketRepository.GetTicket(id);
    }

    public async Task<IActionResult> OnPostPay(long id)
    {
        var orderId = await _orderApplication.PlaceOrder(_authHelper.CurrentAccountId(), id);
        var result = new PaymentResult();
        result = result.Succeeded("پرداخت با موفقیت انجام شد.", id.ToString());
        return RedirectToPage("/PaymentResult", result);
    }

    public async Task<IActionResult> OnGetCallback([FromQuery] string authority, [FromQuery] string statue, [FromQuery] long oId)
    {
        var orderAmount = _orderApplication.GetAmountBy(oId);
        var verificationResponse = _zarinPalFactory.CreateVerificationRequest(authority, orderAmount.ToString(CultureInfo.InvariantCulture));

        var result = new PaymentResult();
        if (statue == "OK" && verificationResponse.Status >= 100)
        {
            var issueTrackingNo = await _orderApplication.PaymentSucceeded(oId, verificationResponse.RefID);
            result = result.Succeeded("پرداخت با موفقیت انجام شد.", issueTrackingNo);
            return RedirectToPage("/PaymentResult", result);
        }

        result = result.Failed("پرداخت ناموفق بود.");
        return RedirectToPage("/PaymentResult", result);
    }
}