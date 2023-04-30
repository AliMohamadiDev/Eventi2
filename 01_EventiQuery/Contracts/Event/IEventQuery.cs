namespace _01_EventiQuery.Contracts.Event;

public interface IEventQuery
{
    Task<EventQueryModel> GetEventDetailsAsync(string slug);
    Task<List<EventQueryModel>> GetLatestEventsAsync(int number);
    Task<List<EventQueryModel>> SearchAsync(string value);
    Task<List<EventQueryModel>> GetEventsByPresenterAsync(string presenterSlug);
    bool UserOwned(long eventId, long accountId, long ticketId);
}