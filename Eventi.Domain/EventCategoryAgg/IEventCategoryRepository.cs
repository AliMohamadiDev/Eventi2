using _0_Framework.Domain;
using Eventi.Application.Contract.EventCategory;

namespace Eventi.Domain.EventCategoryAgg;

public interface IEventCategoryRepository : IRepository<long, EventCategory>
{
    string GetCategorySlugById(long id);
    Task<List<EventCategory>> GetAllAsync();
    Task<EditEventCategory?> GetDetailsAsync(long id);
    Task<List<EventCategoryViewModel>> GetEventCategoriesAsync();
    Task<List<EventCategoryViewModel>> SearchAsync(EventCategorySearchModel searchModel);
}