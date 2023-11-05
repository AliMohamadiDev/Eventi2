using System.Globalization;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using Eventi.Application.Contract.Order;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Pages;

[Authorize]
public class CheckoutModel : PageModel
{
    public EditTicket? Ticket;
    public bool HasThisTicket;

    private readonly IAuthHelper _authHelper;
    private readonly ITicketApplication _ticketApplication;
    private readonly IOrderApplication _orderApplication;
    private readonly IZarinPalFactory _zarinPalFactory;

    public CheckoutModel(ITicketApplication ticketApplication, IOrderApplication orderApplication, IAuthHelper authHelper, IZarinPalFactory zarinPalFactory)
    {
        _ticketApplication = ticketApplication;
        _orderApplication = orderApplication;
        _authHelper = authHelper;
        _zarinPalFactory = zarinPalFactory;
    }

    public async Task OnGet(long id)
    {
        var userId = _authHelper.CurrentAccountId();
        HasThisTicket = await _ticketApplication.UserHasTicketAsync(userId, id);

        Ticket = await _ticketApplication.GetDetailsAsync(id);
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