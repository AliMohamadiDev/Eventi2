using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class CreateModel : PageModel
    {
        public CreateDepartment Command;

        private readonly IAccountSideApplication _accountSideApplication;

        public CreateModel(IAccountSideApplication accountSideApplication)
        {
            _accountSideApplication = accountSideApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateDepartment command)
        {
            var result = _accountSideApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
