using _0_Framework.Domain;
using Eventi.Application.Contract.Ticket;

namespace Eventi.Domain.EventAgg;

public interface ITicketRepository : IRepository<long, Ticket>
{
    Ticket GetTicket(long id);
    Task<EditTicket?> GetDetailsAsync(long id);
    Task<List<TicketViewModel>> GetTicketsAsync();
    Task<List<TicketViewModel>> SearchAsync(TicketSearchModel searchModel);
    void Deactivate(long id);
    void Activate(long id);
}