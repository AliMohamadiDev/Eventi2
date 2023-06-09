using _0_Framework.Application;

namespace Eventi.Application.Contract.Event;

public interface IEventApplication
{
    Task<EditEvent?> GetDetailsAsync(long id);
    Task<List<EventViewModel>> GetEventsAsync();
    Task<OperationResult> EditAsync(EditEvent command);
    Task<OperationResult> CreateAsync(CreateEvent command);
    Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel);
    Task<OperationResult> RemoveAsync(long id);
    Task<OperationResult> RestoreAsync(long id);
    Task<OperationResult> ConfirmAsync(long id);
    Task<OperationResult> CancelAsync(long id);
}