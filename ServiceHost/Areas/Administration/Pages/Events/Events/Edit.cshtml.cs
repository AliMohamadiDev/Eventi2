using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events
{
    public class EditModel : PageModel
    {
        public EditEvent Command;
        public SelectList Categories;
        public SelectList Subcategories;

        private readonly IEventApplication _eventApplication;
        private readonly IEventCategoryApplication _eventCategoryApplication;
        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public EditModel(IEventApplication eventApplication, IEventCategoryApplication eventCategoryApplication, IEventSubcategoryApplication eventSubcategoryApplication)
        {
            _eventApplication = eventApplication;
            _eventCategoryApplication = eventCategoryApplication;
            _eventSubcategoryApplication = eventSubcategoryApplication;
        }

        public async Task OnGet(long id)
        {
            Command = (await _eventApplication.GetDetailsAsync(id))!;
            var categories = await _eventCategoryApplication.GetEventCategoriesAsync();
            Categories = new SelectList(categories, "CategoryId", "CategoryName");

            var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
            Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName", "CategoryId");
        }

        public async Task<IActionResult> OnPostAsync(EditEvent command)
        {
            var result = await _eventApplication.EditAsync(command);
            return RedirectToPage("./Index");
        }
    }
}
