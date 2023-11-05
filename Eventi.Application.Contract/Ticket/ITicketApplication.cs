using _0_Framework.Application;

namespace Eventi.Application.Contract.Ticket;

public interface ITicketApplication
{
    Task<EditTicket> GetDetailsAsync(long id);
    Task<List<TicketViewModel>> GetTicketsAsync();
    Task<OperationResult> EditTicketAsync(EditTicket command);
    Task<OperationResult> CreateTicketAsync(CreateTicket command);
    Task<List<TicketViewModel>> SearchAsync(TicketSearchModel searchModel);
    Task IncreaseUsedNumber(long id);
    Task<bool> UserHasTicketAsync(long userId, long ticketId);
    void Deactivate(long id);
    void Activate(long id);
}