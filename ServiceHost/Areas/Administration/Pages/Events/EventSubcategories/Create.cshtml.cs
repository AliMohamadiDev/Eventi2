using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories
{
    public class CreateModel : PageModel
    {
        public CreateEventSubcategory Command;

        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public CreateModel(IEventSubcategoryApplication eventSubcategoryApplication)
        {
            _eventSubcategoryApplication = eventSubcategoryApplication;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(CreateEventSubcategory command)
        {
            var result = await _eventSubcategoryApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
