using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories
{

    public class EditModel : PageModel
    {
        public EditEventSubcategory Command;
        public SelectList EventCategories;

        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;
        private readonly IEventCategoryApplication _eventCategoryApplication;

        public EditModel(IEventSubcategoryApplication eventSubcategoryApplication, IEventCategoryApplication eventCategoryApplication)
        {
            _eventSubcategoryApplication = eventSubcategoryApplication;
            _eventCategoryApplication = eventCategoryApplication;
        }

        public async Task OnGet(long id)
        {
            Command = (await _eventSubcategoryApplication.GetDetailsAsync(id))!;
            var categoryList = await _eventCategoryApplication.GetEventCategoriesAsync();
            EventCategories = new SelectList(categoryList, "CategoryId", "CategoryName");
        }

        public async Task<IActionResult> OnPost(EditEventSubcategory command)
        {
            var result = await _eventSubcategoryApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
