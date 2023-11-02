using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories
{

    public class EditModel : PageModel
    {
        public EditEventSubcategory Command;

        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public EditModel(IEventSubcategoryApplication eventSubcategoryApplication)
        {
            _eventSubcategoryApplication = eventSubcategoryApplication;
        }

        public async Task OnGet(long id)
        {
            Command = (await _eventSubcategoryApplication.GetDetailsAsync(id))!;
        }

        public async Task<IActionResult> OnPost(EditEventSubcategory command)
        {
            var result = await _eventSubcategoryApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
