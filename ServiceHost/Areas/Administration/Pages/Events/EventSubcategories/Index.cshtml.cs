using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories;

public class IndexModel : PageModel
{
    public EventSubcategorySearchModel SearchModel;
    public List<EventSubcategoryViewModel> EventSubcategories;

    private readonly IEventSubcategoryApplication _eventSubcategoryApplication;

    public IndexModel(IEventSubcategoryApplication eventSubcategoryApplication)
    {
        _eventSubcategoryApplication = eventSubcategoryApplication;
    }

    public async Task OnGet(EventSubcategorySearchModel searchModel)
    {
        EventSubcategories = await _eventSubcategoryApplication.SearchAsync(searchModel);
    }
}