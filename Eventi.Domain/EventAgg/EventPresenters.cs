namespace Eventi.Domain.EventAgg;

public class EventPresenters
{
    public long EventId { get; private set; }
    public Event Event { get; private set; }

    public long PresenterId { get; private set; }
    public Presenter Presenter { get; private set; }
}