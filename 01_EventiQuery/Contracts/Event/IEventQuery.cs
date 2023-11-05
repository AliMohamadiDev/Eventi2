namespace _01_EventiQuery.Contracts.Event;

public interface IEventQuery
{
    Task<EventQueryModel> GetEventDetailsAsync(string slug);
    Task<List<EventQueryModel>> GetLatestEventsAsync(int number, bool isUpcoming = true, bool isPassed = true);
    Task<List<EventQueryModel>> SearchAsync(string value);
    Task<List<EventQueryModel>> GetEventsByPresenterAsync(string presenterSlug);
    bool UserOwned(long eventId, long accountId, long ticketId);
    bool IsConfirmed(long eventId);
}