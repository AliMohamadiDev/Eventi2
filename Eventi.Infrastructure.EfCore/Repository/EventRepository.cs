using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Event;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class EventRepository : RepositoryBase<long, Event>, IEventRepository
{
    private readonly EventiContext _context;

    public EventRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public Event GetEvent(long id)
    {
        return _context.Events.Find(id)!;
    }

    public async Task<EditEvent?> GetDetailsAsync(long id)
    {
        return await _context.Events
            .Include(x => x.EventAccounts)
            .Include(x => x.EventPresenters)
            .Select(x => new EditEvent
            {
                Id = x.Id,
                Name = x.Name,
                SubcategoryId = x.SubcategoryId,
                Slug = x.Slug,
                //PresenterId = x.PresenterId,
                DepartmentId = x.DepartmentId,
                //ImageCover = x.ImageCover,
                ImageCoverTitle = x.ImageCoverTitle,
                ImageCoverAlt = x.ImageCoverAlt,
                Tags = x.Tags,
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                StartTime = x.StartTime.ToString(),
                EndTime = x.EndTime.ToString(),
                IsConfirmed = x.IsConfirmed,
                PresenterIdList = x.EventPresenters.Select(p => p.PresenterId).ToList(),
                AccountIdList = x.EventAccounts.Select(p => p.AccountId).ToList()
            }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<EventViewModel>> GetEventsAsync()
    {
        return await _context.Events.Select(x => new EventViewModel
        {
            Id = x.Id,
            Name = x.Name,
            ImageCover = x.ImageCover,
            //PresenterId = x.PresenterId,
            //Presenter = x.Presenter.Name,
            SubcategoryId = x.SubcategoryId,
            Subcategory = x.Subcategory.SubcategoryName,
            AccountSideId = x.DepartmentId,
            AccountSide = x.Department.NationalCode.ToString(),
            Address = x.Address,
            Description = x.Description,
            EventType = x.EventType,
            SupportNumber = x.SupportNumber,
            StartTime = x.StartTime.ToString(),
            EndTime = x.EndTime.ToString(),
            IsConfirmed = x.IsConfirmed,
            PresenterIdList = x.EventPresenters.Select(x => x.PresenterId).ToList()
        }).ToListAsync();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel, string userRole, long userId)
    {
        var query = _context.Events
            .Include(x => x.EventAccounts)
            .Select(x => new EventViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageCover = x.ImageCover,
                //PresenterId = x.PresenterId,
                //Presenter = x.Presenter.Name,
                SubcategoryId = x.SubcategoryId,
                Subcategory = x.Subcategory.SubcategoryName,
                AccountSideId = x.DepartmentId,
                AccountSide = x.Department.NationalCode.ToString(),
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                StartTime = x.StartTime.ToString(),
                EndTime = x.EndTime.ToString(),
                IsConfirmed = x.IsConfirmed,
                PresenterIdList = x.EventPresenters.Select(e => e.PresenterId).ToList(),
                AccountIdList = x.EventAccounts.Select(e => e.AccountId).ToList()
            });
        
        if (searchModel.Name != null)
        {
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        }

        if (searchModel.PresenterId != 0)
        {
            query = query.Where(x => x.PresenterId == searchModel.PresenterId);
        }

        if (searchModel.SubcategoryId != 0)
        {
            query = query.Where(x => x.SubcategoryId == searchModel.SubcategoryId);
        }

        if (searchModel.AccountSideId != 0)
        {
            query = query.Where(x => x.AccountSideId == searchModel.AccountSideId);
        }

        if (userRole == Roles.Presenter)
        {
            query = query.Where(x => x.AccountIdList.Contains(userId));
        }

        var a = await query.OrderByDescending(x => x.Id).ToListAsync();

        return a;
    }

    public async Task CreateEventWithPresentersAsync(Event newEvent, List<Presenter> presenters, List<Account> accounts)
    {
        newEvent.EventPresenters =
            presenters.Select(p => new EventPresenters {PresenterId = p.Id, EventId = newEvent.Id}).ToList();

        newEvent.EventAccounts =
            accounts.Select(p => new EventAccount {AccountId = p.Id, EventId = newEvent.Id}).ToList();

        await _context.Events.AddAsync(newEvent);
    }
    
    public async Task EditEventWithPresentersAsync(Event newEvent, List<Presenter> presenters, List<Account> accounts)
    {
        var e = await _context.EventPresenters.Where(e => e.EventId == newEvent.Id).ToListAsync();
        _context.EventPresenters.RemoveRange(e);
        
        var a = await _context.EventAccounts.Where(e => e.EventId == newEvent.Id).ToListAsync();
        _context.EventAccounts.RemoveRange(a);

        newEvent.EventPresenters =
            presenters.Select(p => new EventPresenters {PresenterId = p.Id, EventId = newEvent.Id}).ToList();

        newEvent.EventAccounts =
            accounts.Select(p => new EventAccount { AccountId = p.Id, EventId = newEvent.Id }).ToList();
    }

    public void Remove(long id)
    {
        _context.Events.Find(id).Remove();
    }

    public void Restore(long id)
    {
        _context.Events.Find(id).Restore();
    }
}