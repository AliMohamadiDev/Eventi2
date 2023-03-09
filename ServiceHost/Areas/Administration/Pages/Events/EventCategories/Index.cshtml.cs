using Eventi.Application.Contract.EventCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Events.EventCategories;

public class IndexModel : PageModel
{
    public EventCategorySearchModel SearchModel;
    public List<EventCategoryViewModel> EventCategories;

    private readonly IEventCategoryApplication _eventCategoryApplication;

    public IndexModel(IEventCategoryApplication eventCategoryApplication)
    {
        _eventCategoryApplication = eventCategoryApplication;
    }

    public async Task OnGet(EventCategorySearchModel searchModel)
    {
        EventCategories = await _eventCategoryApplication.SearchAsync(searchModel);
    }
}