using _0_Framework.Infrastructure;
using Eventi.Application.Contract.DiscountCode;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class DiscountCodeRepository : RepositoryBase<long, DiscountCode>,IDiscountCodeRepository
{
    private readonly EventiContext _context;

    public DiscountCodeRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public DiscountCode GetDiscountCode(long id)
    {
        return _context.DiscountCodes.Find(id)!;
    }

    public async Task<EditDiscountCode?> GetDetailsAsync(long id)
    {
        return await _context.DiscountCodes.Select(x => new EditDiscountCode
        {
            Id = x.Id,
            Count = x.Count,
            Code = x.Code,
            DiscountRate = x.DiscountRate,
            TicketId = x.TicketId
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<DiscountCodeViewModel>> GetDiscountCodesAsync()
    {
        return await _context.DiscountCodes.Select(x => new DiscountCodeViewModel
        {
            Id = x.Id,
            Code = x.Code,
            Count = x.Count,
            TicketId = x.TicketId,
            Ticket = x.Ticket.Title,
            CountUsed = x.CountUsed,
            DiscountRate = x.DiscountRate,
        }).ToListAsync();
    }

    public async Task<List<DiscountCodeViewModel>> SearchAsync(DiscountCodeSearchModel searchModel)
    {
        var query = _context.DiscountCodes.Select(x => new DiscountCodeViewModel
        {
            Id = x.Id,
            Code = x.Code,
            Count = x.Count,
            TicketId = x.TicketId,
            Ticket = x.Ticket.Title,
            CountUsed = x.CountUsed,
            DiscountRate = x.DiscountRate,
        });

        if (searchModel.Id != 0)
        {
            query = query.Where(x => x.Id == searchModel.Id);
        }

        if (searchModel.TicketId != 0)
        {
            query = query.Where(x => x.TicketId == searchModel.TicketId);
        }

        if (searchModel.DiscountRate != 0)
        {
            query = query.Where(x => x.DiscountRate == searchModel.DiscountRate);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }
}