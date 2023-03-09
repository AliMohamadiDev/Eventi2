using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories
{
    public class CreateModel : PageModel
    {
        public CreateEventSubcategory Command;
        public SelectList EventCategories;

        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;
        private readonly  IEventCategoryApplication _eventCategoryApplication;

        public CreateModel(IEventSubcategoryApplication eventSubcategoryApplication, IEventCategoryApplication eventCategoryApplication)
        {
            _eventSubcategoryApplication = eventSubcategoryApplication;
            _eventCategoryApplication = eventCategoryApplication;
        }

        public async Task OnGet()
        {
            var categoryList = await _eventCategoryApplication.GetEventCategoriesAsync();
            EventCategories = new SelectList(categoryList, "CategoryId", "CategoryName");
        }

        public async Task<IActionResult> OnPost(CreateEventSubcategory command)
        {
            var result = await _eventSubcategoryApplication.CreateAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
