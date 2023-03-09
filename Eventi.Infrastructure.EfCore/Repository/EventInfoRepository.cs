using _0_Framework.Infrastructure;
using Eventi.Application.Contract.EventInfo;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class EventInfoRepository : RepositoryBase<long, EventInfo>, IEventInfoRepository
{
    private readonly EventiContext _context;

    public EventInfoRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public EventInfo GetEventInfo(long id)
    {
        return _context.EventInfos.Find(id)!;
    }

    public async Task<EditEventInfo?> GetDetailsAsync(long id)
    {
        return await _context.EventInfos.Select(x => new EditEventInfo
        {
            Id = x.Id,
            IsWebinar = x.IsWebinar,
            IsPersonalSystem = x.IsPersonalSystem,
            Length = x.Length,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            State = x.State,
            City = x.City,
            Address = x.Address,
            HostingService = x.HostingService,
            LoginLink = x.LoginLink,
            Description = x.Description,
            EventId = x.EventId,
            RoomCapacity = x.RoomCapacity,
            TotalHours = x.TotalHours
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<EventInfoViewModel>> GetEventInfosAsync()
    {
        return await _context.EventInfos.Select(x => new EventInfoViewModel
        {
            Id = x.Id,
            IsWebinar = x.IsWebinar,
            IsPersonalSystem = x.IsPersonalSystem,
            Length = x.Length,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            State = x.State,
            City = x.City,
            Address = x.Address,
            HostingService = x.HostingService,
            LoginLink = x.LoginLink,
            Description = x.Description,
            EventId = x.EventId,
            RoomCapacity = x.RoomCapacity,
            TotalHours = x.TotalHours,
            Event = x.Event.Name
        }).ToListAsync();
    }

    public async Task<List<EventInfoViewModel>> SearchAsync(EventInfoSearchModel searchModel)
    {
        var query = _context.EventInfos.Select(x => new EventInfoViewModel
        {
            Id = x.Id,
            IsWebinar = x.IsWebinar,
            IsPersonalSystem = x.IsPersonalSystem,
            Length = x.Length,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            State = x.State,
            City = x.City,
            Address = x.Address,
            HostingService = x.HostingService,
            LoginLink = x.LoginLink,
            Description = x.Description,
            EventId = x.EventId,
            RoomCapacity = x.RoomCapacity,
            TotalHours = x.TotalHours,
            Event = x.Event.Name
        });

        if (searchModel.EventId != 0)
        {
            query = query.Where(x => x.EventId == searchModel.EventId);
        }

        if (searchModel.IsWebinar)
        {
            query = query.Where(x => x.IsWebinar);
        }
        
        if (searchModel.IsPersonalSystem)
        {
            query = query.Where(x => x.IsPersonalSystem);
        }

        if (searchModel.City != null)
        {
            query = query.Where(x => x.City!.Contains(searchModel.City));
        }

        if (searchModel.State != null)
        {
            query = query.Where(x => x.State!.Contains(searchModel.State));
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }
}