using System.Globalization;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using Eventi.Application.Contract.Order;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.EventAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost.Pages;

[Authorize]
public class CheckoutModel : PageModel
{
    public Ticket Ticket;
    [BindProperty]
    public string Code { get; set; }

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

    public IActionResult OnPostApplyDiscount()
    {
        // اینجا می‌توانید کد تخفیف را بررسی کرده و میزان تخفیف را محاسبه کنید.
        // به عنوان مثال، اگر کد تخفیف "DISCOUNT123" باشد:
        if (Code == "DISCOUNT123")
        {
            // میزان تخفیف 20٪
            return new JsonResult(new { success = true, discountAmount = 20 });
        }
        else
        {
            return new JsonResult(new { success = false });
        }
    }

    public async Task<IActionResult> CheckCode(string code)
    {

        if (code == "DISCOUNT123")
        {
            // میزان تخفیف 20٪
            return new JsonResult(new { success = true, discountAmount = 20 });
        }
        else
        {
            return new JsonResult(new { success = false });
        }

        // Check if the discount code is in the database
        /*var discount = await _context.Discounts.FirstOrDefaultAsync(d => d.Code == code);

        // If the discount code is found, return it
        if (discount != null)
        {
            return Json(new DiscountModel
            {
                Code = discount.Code,
                Price = discount.Price,
                Discount = discount.Discount
            });
        }

        // If the discount code is not found, return an error
        return Json(new { success = false });*/
    }

    public IActionResult OnGetHelloWorld()
    {
        return new JsonResult("Hello, World!");
    }
    public JsonResult OnPostGetData()
    {
        var data = new { message = "داده‌ها از متد OnPostGetData دریافت شدند" };
        return new JsonResult(data);
    }
}