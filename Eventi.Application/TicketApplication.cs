using _0_Framework.Application;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class TicketApplication : ITicketApplication
{
    private readonly ITicketRepository _ticketRepository;

    public TicketApplication(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
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

        double price;
        if (command.IsFree)
        {
            price = 0;
        }
        else
        {
            price = command.Price;
        }

        ticket.Edit(command.Title, command.Description, command.Number, command.IsFree, price,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId);

        await _ticketRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateTicketAsync(CreateTicket command)
    {
        var operation = new OperationResult();

        double price;
        if (command.IsFree)
        {
            price = 0;
        }
        else
        {
            price = command.Price;
        }

        var ticket = new Ticket(command.Title, command.Description, command.Number, command.IsFree, price,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId);

        await _ticketRepository.CreateAsync(ticket);
        await _ticketRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<TicketViewModel>> SearchAsync(TicketSearchModel searchModel)
    {
        return await _ticketRepository.SearchAsync(searchModel);
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