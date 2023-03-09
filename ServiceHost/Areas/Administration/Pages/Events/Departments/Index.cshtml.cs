using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class IndexModel : PageModel
    {
        public DepartmentSearchModel SearchModel;
        public List<DepartmentViewModel> AccountSides;

        private readonly IAccountSideApplication _accountSideApplication;

        public IndexModel(IAccountSideApplication accountSideApplication)
        {
            _accountSideApplication = accountSideApplication;
        }

        public async Task OnGet(DepartmentSearchModel searchModel)
        {
            AccountSides = await _accountSideApplication.SearchAsync(searchModel);
        }
    }
}
