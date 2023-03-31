using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Roles;

public class CreateModel : PageModel
{
    public CreateRole Command;
    public List<SelectListItem> Permissions = new();

    private readonly IEnumerable<IPermissionExposer> _exposers;
    private readonly IRoleApplication _roleApplication;

    public CreateModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
    {
        _roleApplication = roleApplication;
        _exposers = exposers;
    }

    public void OnGet()
    {
        var permissions = new List<PermissionDto>();
        foreach (var exposer in _exposers)
        {
            var exposedPermissions = exposer.Expose();
            foreach (var (key, value) in exposedPermissions)
            {
                permissions.AddRange(value);
                var group = new SelectListGroup
                {
                    Name = key
                };

                foreach (var permission in value)
                {
                    var item = new SelectListItem(permission.Name, permission.Code.ToString())
                    {
                        Group = group
                    };

                    Permissions.Add(item);
                }
            }
        }
    }

    public async Task<IActionResult> OnPostAsync(CreateRole command)
    {
        var result = await _roleApplication.CreateAsync(command);
        return RedirectToPage("./Index");
    }
}