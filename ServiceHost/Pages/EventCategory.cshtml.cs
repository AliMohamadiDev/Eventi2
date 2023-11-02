using _01_EventiQuery.Contracts.EventCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages;

public class EventCategoryModel : PageModel
{
    public EventSubcategoryQueryModel EventCategory;
    public List<EventSubcategoryQueryModel> EventSubcategories;

    private readonly IEventCategoryQuery _eventCategoryQuery;

    public EventCategoryModel(IEventCategoryQuery eventCategoryQuery)
    {
        _eventCategoryQuery = eventCategoryQuery;
    }

    public async Task OnGetAsync(string id)
    {
        EventCategory = await _eventCategoryQuery.GetEventSubcategoryAsync(id);
        EventSubcategories = await _eventCategoryQuery.GetEventSubcategoriesAsync();
    }
}