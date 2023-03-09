namespace _01_EventiQuery.Contracts.EventCategory;

public interface IEventCategoryQuery
{
    Task<EventCategoryQueryModel> GetEventCategoryAsync(string slug);
    Task<List<EventCategoryQueryModel>> GetEventCategoriesAsync();
    Task<EventSubcategoryQueryModel> GetEventSubcategoryAsync(string slug);
    Task<List<EventSubcategoryQueryModel>> GetEventSubcategoriesAsync();
}