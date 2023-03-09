using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Roles;

public class CreateModel : PageModel
{
    public CreateRole Command;
    public List<SelectListItem> Permissions = new();

    private readonly IRoleApplication _roleApplication;

    public CreateModel(IRoleApplication roleApplication)
    {
        _roleApplication = roleApplication;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(CreateRole command)
    {
        var result = await _roleApplication.CreateAsync(command);
        return RedirectToPage("./Index");
    }
}