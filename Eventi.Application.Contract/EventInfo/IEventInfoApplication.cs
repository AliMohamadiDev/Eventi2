using _0_Framework.Application;

namespace Eventi.Application.Contract.EventInfo;

public interface IEventInfoApplication
{
    Task<EditEventInfo?> GetDetailsAsync(long id);
    Task<List<EventInfoViewModel>> GetEventInfosAsync();
    Task<OperationResult> EditEventInfoAsync(EditEventInfo command);
    Task<OperationResult> CreateEventInfo(CreateEventInfo command);
    Task<List<EventInfoViewModel>> SearchAsync(EventInfoSearchModel searchModel);
}