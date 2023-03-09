using Eventi.Application.Contract.EventCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventCategories
{
    public class CreateModel : PageModel
    {
        public CreateEventCategory Command;
        //public SelectList EventSubcategories;

        private readonly IEventCategoryApplication _eventCategoryApplication;

        public CreateModel(IEventCategoryApplication eventCategoryApplication)
        {
            _eventCategoryApplication = eventCategoryApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreateEventCategory command)
        {
            var result = _eventCategoryApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
