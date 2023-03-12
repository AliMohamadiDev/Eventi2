using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.EventAgg;

public class AccountTicket
{
    public long AccountId { get; private set; }
    public Account Account { get; private set; }

    public long TicketId { get; private set; }
    public Ticket Ticket { get; private set; }

    public long EventId { get; private set; }
    public Event Event { get; private set; }
}