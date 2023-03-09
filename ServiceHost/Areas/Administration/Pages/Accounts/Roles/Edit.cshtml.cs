using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Roles;

public class EditModel : PageModel
{
    public EditRole Command;
    public List<SelectListItem> Permissions = new();

    private readonly IRoleApplication _roleApplication;
    private readonly IEnumerable<IPermissionExposer> _exposers;

    public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
    {
        _roleApplication = roleApplication;
        _exposers = exposers;
    }

    public async Task OnGet(long id)
    {
        Command = await _roleApplication.GetDetailsAsync(id);

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
                    
                    if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                    {
                        item.Selected = true;
                    }

                    Permissions.Add(item);
                }
            }
        }
    }

    public async Task<IActionResult> OnPostAsync(EditRole command)
    {
        var result = await _roleApplication.EditAsync(command);
        return RedirectToPage("./Index");
    }
}