using _0_Framework.Application;

namespace Eventi.Application.Contract.EventSubcategory;

public interface IEventSubcategoryApplication
{
    Task<EditEventSubcategory?> GetDetailsAsync(long id);
    Task<OperationResult> EditAsync(EditEventSubcategory command);
    Task<OperationResult> CreateAsync(CreateEventSubcategory command);
    Task<List<EventSubcategoryViewModel>> GetEventSubcategoriesAsync();
    Task<List<EventSubcategoryViewModel>> SearchAsync(EventSubcategorySearchModel searchModel);
}