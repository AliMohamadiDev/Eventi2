using _0_Framework.Application;
using _01_EventiQuery.Contracts.Account;
using _01_EventiQuery.Contracts.Event;
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
    public EditAccount EditCommand;

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
        var id = _authHelper.CurrentAccountId();

        ChangePassword cp = new ChangePassword
        {
            Password = command.Password,
            RePassword = command.ConfirmPassword,
            Id = id
        };

        var result = await _accountApplication.ChangePasswordAsync(cp);
        return RedirectToPage("./Profile");
    }

    public async Task<IActionResult> OnPostEditAsync(EditAccount editCommand)
    {
        var account = (await _accountApplication.GetDetailsAsync(_authHelper.CurrentAccountId()))!;
        account.Fullname = editCommand.Fullname;
        account.ProfilePhoto = editCommand.ProfilePhoto;
        account.Birthday = editCommand.Birthday;
        account.State = editCommand.State;
        account.City = editCommand.City;
        account.NationalCode = editCommand.NationalCode;
        account.FatherName = editCommand.FatherName;
        account.Gender = editCommand.Gender;
        account.EducationalCenter = editCommand.EducationalCenter;
        account.ScientificField = editCommand.ScientificField;
        account.UniversityDegree = editCommand.UniversityDegree;
        account.SeminaryDegree = editCommand.SeminaryDegree;
        account.PostalCode = editCommand.PostalCode;
        account.Address = editCommand.Address;

        var result = await _accountApplication.EditAsync(account);

        return RedirectToPage("./Profile");
    }
}

public class Cp
{
    public string Password { get; set; }

    [BindProperty(Name = "confirm-password")]
    public string ConfirmPassword { get; set; }
}