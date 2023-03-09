using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.Events
{
    public class IndexModel : PageModel
    {
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
    }
}
