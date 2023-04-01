using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class EditModel : PageModel
    {
        public EditDepartment Command;

        private readonly IDepartmentApplication _departmentApplication;

        public EditModel(IDepartmentApplication departmentApplication)
        {
            _departmentApplication = departmentApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = await _departmentApplication.GetDetailsAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(EditDepartment command)
        {
            var result = await _departmentApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
