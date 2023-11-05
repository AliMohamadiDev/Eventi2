using _0_Framework.Domain;
using Eventi.Application.Contract.Event;
using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.EventAgg;

public interface IEventRepository : IRepository<long, Event>
{
    Event GetEvent(long id);
    Task<EditEvent?> GetDetailsAsync(long id);
    Task<List<EventViewModel>> GetEventsAsync();
    Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel, string userRole, long userId);
    Task CreateEventWithPresentersAsync(Event newEvent, List<Presenter> presenters, List<Account> accounts);
    Task EditEventWithPresentersAsync(Event newEvent, List<Presenter> presenters, List<Account> accounts);
    void Remove(long id);
    void Restore(long id);
}