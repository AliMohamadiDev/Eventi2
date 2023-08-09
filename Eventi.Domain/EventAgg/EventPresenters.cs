namespace Eventi.Domain.EventAgg;

public class EventPresenters
{
    public long EventId { get; set; }
    public Event Event { get; private set; }

    public long PresenterId { get; set; }
    public Presenter Presenter { get; set; }
}