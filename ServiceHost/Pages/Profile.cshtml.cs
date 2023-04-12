using _0_Framework.Application;
using _01_EventiQuery.Contracts.Account;
using Eventi.Application.Contract.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

[Authorize]
public class ProfileModel : PageModel
{
    public AccountQueryModel Account;
    public AuthViewModel CurrentAccount;

    private readonly IAccountApplication _accountApplication;
    private readonly IAccountQuery _accountQuery;
    private readonly IAuthHelper _authHelper;

    public ProfileModel(IAccountApplication accountApplication, IAccountQuery accountQuery, IAuthHelper authHelper)
    {
        _accountApplication = accountApplication;
        _accountQuery = accountQuery;
        _authHelper = authHelper;
    }

    public async Task OnGetAsync()
    {
        CurrentAccount = _authHelper.CurrentAccountInfo();
        Account = (await _accountQuery.GetAccountDetailsAsync(CurrentAccount.Id))!;
    }

    public async Task<IActionResult> OnPostChangePasswordAsync(Cp command)
    {
        var id = _authHelper.CurrentAccountInfo().Id;

        ChangePassword cp = new ChangePassword
        {
            Password = command.Password,
            RePassword = command.ConfirmPassword,
            Id = id
        };

        var result = await _accountApplication.ChangePasswordAsync(cp);
        return RedirectToPage("./Profile");
    }
}

public class Cp
{
    public string Password { get; set; }

    [BindProperty(Name = "confirm-password")]
    public string ConfirmPassword { get; set; }
}