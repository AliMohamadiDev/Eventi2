using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class IndexModel : PageModel
    {
        public DepartmentSearchModel SearchModel;
        public List<DepartmentViewModel> AccountSides;

        private readonly IDepartmentApplication _departmentApplication;

        public IndexModel(IDepartmentApplication departmentApplication)
        {
            _departmentApplication = departmentApplication;
        }

        public async Task OnGet(DepartmentSearchModel searchModel)
        {
            AccountSides = await _departmentApplication.SearchAsync(searchModel);
        }
    }
}
