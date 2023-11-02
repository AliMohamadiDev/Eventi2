namespace _01_EventiQuery.Contracts.EventCategory;

public interface IEventCategoryQuery
{
    Task<EventSubcategoryQueryModel> GetEventSubcategoryAsync(string slug);
    Task<List<EventSubcategoryQueryModel>> GetEventSubcategoriesAsync();
}