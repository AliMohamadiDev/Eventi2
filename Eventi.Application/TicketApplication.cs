using _0_Framework.Application;
using Eventi.Application.Contract.DiscountCode;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class TicketApplication : ITicketApplication
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IDiscountCodeApplication _discountCodeApplication;

    public TicketApplication(ITicketRepository ticketRepository, IDiscountCodeApplication discountCodeApplication)
    {
        _ticketRepository = ticketRepository;
        _discountCodeApplication = discountCodeApplication;
    }

    public async Task<EditTicket> GetDetailsAsync(long id)
    {
        return (await _ticketRepository.GetDetailsAsync(id))!;
    }

    public async Task<List<TicketViewModel>> GetTicketsAsync()
    {
        return await _ticketRepository.GetTicketsAsync();
    }

    public async Task<OperationResult> EditTicketAsync(EditTicket command)
    {
        var operation = new OperationResult();
        var ticket = _ticketRepository.GetTicket(command.Id);

        var totalPrice = (command.Price - (command.Price * command.DiscountRate) / 100);

        ticket.Edit(command.Title, command.Description, command.Number, command.Price,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId, totalPrice);

        await _ticketRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateTicketAsync(CreateTicket command)
    {
        var operation = new OperationResult();

        var totalPrice = (command.Price - (command.Price * command.DiscountRate) / 100);

        var ticket = new Ticket(command.Title, command.Description, command.Number, command.Price,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId, totalPrice);

        await _ticketRepository.CreateAsync(ticket);
        await _ticketRepository.SaveChangesAsync();

        var ticketId = ticket.Id;
        if (command.DiscountCodes.Count > 0)
        {
            foreach (var code in command.DiscountCodes)
            {
                code.TicketId = ticketId;
                await _discountCodeApplication.CreateDiscountCodeAsync(code);
            }

            await _ticketRepository.SaveChangesAsync();
        }

        return operation.Succeeded();
    }

    public async Task<List<TicketViewModel>> SearchAsync(TicketSearchModel searchModel)
    {
        return await _ticketRepository.SearchAsync(searchModel);
    }

    public async Task IncreaseUsedNumber(long id)
    {
        var ticket = _ticketRepository.GetTicket(id);
        ticket.IncreaseUsed();
        await _ticketRepository.SaveChangesAsync();
    }

    public async Task<bool> UserHasTicketAsync(long userId, long ticketId)
    {
        return await _ticketRepository.UserHasTicketAsync(userId, ticketId);
    }

    public void Deactivate(long id)
    {
        _ticketRepository.Deactivate(id);
    }

    public void Activate(long id)
    {
        _ticketRepository.Activate(id);
    }
}