using _0_Framework.Domain;
using Eventi.Application.Contract.Event;

namespace Eventi.Domain.EventAgg;

public interface IEventRepository : IRepository<long, Event>
{
    Event GetEvent(long id);
    Task<EditEvent?> GetDetailsAsync(long id);
    Task<List<EventViewModel>> GetEventsAsync();
    Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel);
}