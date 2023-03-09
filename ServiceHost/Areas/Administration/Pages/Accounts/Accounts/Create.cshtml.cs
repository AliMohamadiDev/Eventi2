using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Accounts
{
    public class CreateModel : PageModel
    {
        public RegisterAccount Command;
        public SelectList Roles;

        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;

        public CreateModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        public async Task OnGetAsync()
        {
            var roles = await _roleApplication.ListAsync();
            Roles = new SelectList(roles, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync(RegisterAccount command)
        {
            var result = await _accountApplication.RegisterAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
