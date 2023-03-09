using Eventi.Application.Contract.EventCategory;
using Eventi.Application.Contract.EventSubcategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Events.EventSubcategories;

public class IndexModel : PageModel
{
    public EventSubcategorySearchModel SearchModel;
    public List<EventSubcategoryViewModel> EventSubcategories;
    public SelectList EventCategories;

    private readonly IEventSubcategoryApplication _eventSubcategoryApplication;
    private readonly IEventCategoryApplication _eventCategoryApplication;

    public IndexModel(IEventSubcategoryApplication eventSubcategoryApplication, IEventCategoryApplication eventCategoryApplication)
    {
        _eventSubcategoryApplication = eventSubcategoryApplication;
        _eventCategoryApplication = eventCategoryApplication;
    }

    public async Task OnGet(EventSubcategorySearchModel searchModel)
    {
        EventSubcategories = await _eventSubcategoryApplication.SearchAsync(searchModel);
        var categoryList = await _eventCategoryApplication.GetEventCategoriesAsync();
        EventCategories = new SelectList(categoryList, "CategoryId", "CategoryName");
    }
}