using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.EventAgg;

public class EventAccount
{
    public long EventId { get; set; }
    public Event Event { get; private set; }

    public long AccountId { get; set; }
    public Account Account { get; private set; }
}