using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class CreateModel : PageModel
    {
        public CreateDepartment Command;

        private readonly IDepartmentApplication _departmentApplication;

        public CreateModel(IDepartmentApplication departmentApplication)
        {
            _departmentApplication = departmentApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateDepartment command)
        {
            var result = _departmentApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
