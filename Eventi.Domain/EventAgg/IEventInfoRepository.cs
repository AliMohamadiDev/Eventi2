using _0_Framework.Domain;
using Eventi.Application.Contract.EventInfo;

namespace Eventi.Domain.EventAgg;

public interface IEventInfoRepository : IRepository<long, EventInfo>
{
    EventInfo GetEventInfo(long id);
    Task<EditEventInfo?> GetDetailsAsync(long id);
    Task<List<EventInfoViewModel>> GetEventInfosAsync();
    Task<List<EventInfoViewModel>> SearchAsync(EventInfoSearchModel searchModel);
}