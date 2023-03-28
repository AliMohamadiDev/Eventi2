using Eventi.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class RegisterModel : PageModel
{
    [TempData] public string RegisterMessage { get; set; }
    public RegisterAccount Command;

    private readonly IAccountApplication _accountApplication;

    public RegisterModel(IAccountApplication accountApplication)
    {
        _accountApplication = accountApplication;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(RegisterAccount command)
    {
        var result = await _accountApplication.RegisterAsync(command);

        if (result.IsSucceeded)
        {
            RegisterMessage = result.Message;
            return RedirectToPage("/Index");
        }

        RegisterMessage = result.Message;
        return RedirectToPage("/Index");
    }
}