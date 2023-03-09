
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Accounts
{
    public class EditModel : PageModel
    {
        public EditAccount Command;
        public SelectList Roles;

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public EditModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = (await _accountApplication.GetDetailsAsync(id))!;
            var roles = await _roleApplication.ListAsync();
            Roles = new SelectList(roles, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(EditAccount command)
        {
            var result = await _accountApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
