using _0_Framework.Application;
using Eventi.Application.Contract.EventSubcategory;

namespace Eventi.Application.Contract.EventCategory;

public interface IEventCategoryApplication
{
    Task<OperationResult> CreateAsync(CreateEventCategory command);
    Task<OperationResult> EditAsync(EditEventCategory command);
    Task<EditEventCategory?> GetDetailsAsync(long id);
    Task<List<EventCategoryViewModel>> GetEventCategoriesAsync();
    Task<List<EventCategoryViewModel>> SearchAsync(EventCategorySearchModel searchModel);
    Task<List<EventSubcategoryViewModel>> GetSubcategoriesAsync(long categoryId);
}