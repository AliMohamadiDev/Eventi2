using Eventi.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class LoginModel : PageModel
{
    [TempData] public string LoginMessage { get; set; }
    public Login Command;

    private readonly IAccountApplication _accountApplication;

    public LoginModel(IAccountApplication accountApplication)
    {
        _accountApplication = accountApplication;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(Login command)
    {
        var result = await _accountApplication.LoginAsync(command);

        if (result.IsSucceeded)
        {
            LoginMessage = result.Message;
            return RedirectToPage("./Index");
        }

        LoginMessage = result.Message;
        return Page();
    }

    public IActionResult OnPostLogoutAsync()
    {
        _accountApplication.Logout();
        return RedirectToPage("/Index");
    }
}