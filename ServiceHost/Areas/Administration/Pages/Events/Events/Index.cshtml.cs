using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public EventSearchModel SearchModel;
        public List<EventViewModel> Events;
        public SelectList Subcategories;

        private readonly IEventApplication _eventApplication;
        private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

        public IndexModel(IEventApplication eventApplication, IEventSubcategoryApplication eventSubcategoryApplication)
        {
            _eventApplication = eventApplication;
            _eventSubcategoryApplication = eventSubcategoryApplication;
        }

        public async Task OnGet(EventSearchModel searchModel)
        {
            Events = await _eventApplication.SearchAsync(searchModel);

            var subcategories = await _eventSubcategoryApplication.GetEventSubcategoriesAsync();
            Subcategories = new SelectList(subcategories, "SubcategoryId", "SubcategoryName");
        }

        public async Task<IActionResult> OnGetCancelAsync(long id)
        {
            var result = await _eventApplication.CancelAsync(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetConfirmAsync(long id)
        {
            var result = await _eventApplication.ConfirmAsync(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
