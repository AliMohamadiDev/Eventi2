using Eventi.Application.Contract.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.Departments
{
    public class EditModel : PageModel
    {
        public EditDepartment Command;

        private readonly IAccountSideApplication _accountSideApplication;

        public EditModel(IAccountSideApplication accountSideApplication)
        {
            _accountSideApplication = accountSideApplication;
        }

        public async Task OnGetAsync(long id)
        {
            Command = await _accountSideApplication.GetDetailsAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(EditDepartment command)
        {
            var result = await _accountSideApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
