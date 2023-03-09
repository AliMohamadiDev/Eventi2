
using Eventi.Application.Contract.Account;
using Eventi.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Accounts
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;

        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IRoleApplication roleApplication, IAccountApplication accountApplication)
        {
            _roleApplication = roleApplication;
            _accountApplication = accountApplication;
        }

        public async Task OnGet(AccountSearchModel searchModel)
        {
            Accounts = await _accountApplication.SearchAsync(searchModel);
            var roles = await _roleApplication.ListAsync();
            Roles = new SelectList(roles, "Id", "Name");
        }
    }
}
