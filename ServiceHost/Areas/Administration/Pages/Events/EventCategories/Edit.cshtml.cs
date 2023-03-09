using Eventi.Application.Contract.EventCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.EventCategories
{

    public class EditModel : PageModel
    {
        public EditEventCategory Command;
        //public SelectList EventSubcategories;

        private readonly IEventCategoryApplication _eventCategoryApplication;

        public EditModel(IEventCategoryApplication eventCategoryApplication)
        {
            _eventCategoryApplication = eventCategoryApplication;
        }

        public async Task OnGet(long id)
        {
            Command = await _eventCategoryApplication.GetDetailsAsync(id);
        }

        public async Task<IActionResult> OnPost(EditEventCategory command)
        {
            var result = await _eventCategoryApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
