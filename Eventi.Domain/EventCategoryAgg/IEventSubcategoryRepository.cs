using _0_Framework.Domain;
using Eventi.Application.Contract.EventSubcategory;

namespace Eventi.Domain.EventCategoryAgg;

public interface IEventSubcategoryRepository : IRepository<long, EventSubcategory>
{
    string GetSubcategorySlugById(long id);
    Task<List<EventSubcategory>> GetAllAsync();
    Task<EditEventSubcategory?> GetDetailsAsync(long id); 
    Task<List<EventSubcategoryViewModel>> GetEventSubcategoriesAsync();
    Task<List<EventSubcategoryViewModel>> SearchAsync(EventSubcategorySearchModel searchModel);
}