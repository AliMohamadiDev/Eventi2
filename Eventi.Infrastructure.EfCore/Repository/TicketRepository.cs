using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class TicketRepository : RepositoryBase<long, Ticket>, ITicketRepository
{
    private readonly EventiContext _context;

    public TicketRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public Ticket GetTicket(long id)
    {
        return _context.Tickets.Find(id)!;
    }

    public async Task<EditTicket?> GetDetailsAsync(long id)
    {
        return await _context.Tickets.Select(x => new EditTicket
        {
            Id = x.Id,
            Title = x.Title,
            Number = x.Number,
            UsedNumber = x.UsedNumber,
            Price = x.Price,
            DiscountRate = x.DiscountRate,
            TotalPrice = x.TotalPrice,
            Description = x.Description,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            EventId = x.EventId
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TicketViewModel>> GetTicketsAsync()
    {
        return await _context.Tickets.Select(x => new TicketViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Number = x.Number,
            UsedNumber = x.UsedNumber,
            Price = x.Price,
            DiscountRate = x.DiscountRate,
            TotalPrice = x.TotalPrice,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            Event = x.Event.Name
        }).ToListAsync();
    }

    public async Task<List<TicketViewModel>> SearchAsync(TicketSearchModel searchModel)
    {
        var query = _context.Tickets.Select(x => new TicketViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Number = x.Number,
            UsedNumber = x.UsedNumber,
            Price = x.Price,
            DiscountRate = x.DiscountRate,
            TotalPrice = x.TotalPrice,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            Event = x.Event.Name
        });

        if (searchModel.Id != 0)
        {
            query = query.Where(x => x.Id == searchModel.Id);
        }

        if (searchModel.Title != null)
        {
            query = query.Where(x => x.Title.Contains(searchModel.Title));
        }

        if (searchModel.IsFree)
        {
            query = query.Where(x => x.Price == 0);
        }

        if (searchModel.EventId != 0)
        {
            query = query.Where(x => x.EventId == searchModel.EventId);
        }

        if (searchModel.Price > 0)
        {
            query = query.Where(x => x.Price <= searchModel.Price);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }

    public void Deactivate(long id)
    {
        _context.Tickets.Find(id)?.Deactivate();
    }

    public void Activate(long id)
    {
        _context.Tickets.Find(id)?.Activate();
    }
}