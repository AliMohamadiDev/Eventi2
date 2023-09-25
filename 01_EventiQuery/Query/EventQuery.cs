using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.Presenter;
using Eventi.Domain.EventAgg;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class EventQuery : IEventQuery
{
    private readonly EventiContext _eventContext;

    public EventQuery(EventiContext eventContext)
    {
        _eventContext = eventContext;
    }

    private async Task<PresenterQueryModel> MapPresenterAsync(long id)
    {
        return await _eventContext.Presenters
            .Include(x => x.EventPresenters)
            .Select(x => new PresenterQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Description = x.Description,
                Number = x.Number,
                Policy = x.Policy,
                Website = x.Website,
                Slug = x.Slug,
                EventCount = _eventContext.EventPresenters.Count(p => p.PresenterId==id)
            }).FirstOrDefaultAsync(x => x.Id == id) ?? new PresenterQueryModel();
    }

    public async Task<EventQueryModel> GetEventDetailsAsync(string slug)
    {
        var event1 = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x => x.EventPresenters)
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                IsConfirmed = x.IsConfirmed,
                DepartmentName = x.Department.Name,
                DepartmentSlug = x.Department.Slug,
                DepartmentLogo = x.Department.Logo,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                PresenterIdList = x.EventPresenters.Select(p => p.PresenterId).ToList()
            }).FirstOrDefaultAsync(x => x.Slug == slug);

        event1!.Presenters = new();
        foreach (var presenterId in event1.PresenterIdList)
        {
            event1.Presenters.Add(await MapPresenterAsync(presenterId));
        }

        var a = event1;

        return event1;
    }


    public async Task<List<EventQueryModel>> GetLatestEventsAsync(int number, bool isUpcoming = true,
        bool isPassed = true)
    {
        var events = _eventContext.Events
            .Include(x => x.Subcategory)
            .Where(x => x.IsConfirmed);

        if (isUpcoming && isPassed)
        {
        }

        else if (isUpcoming)
        {
            events = events.Where(x => x.StartTime.Date >= DateTime.Now.Date);
        }

        else if (isPassed)
        {
            events = events.Where(x => x.EndTime.Date <= DateTime.Now.Date);
        }

        var finalEvent = await events.Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                IsConfirmed = x.IsConfirmed,
                DepartmentName = x.Department.Name,
                DepartmentSlug = x.Department.Slug,
                DepartmentLogo = x.Department.Logo,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
        }).OrderByDescending(x => x.Id)
            .Take(number).ToListAsync();

        return finalEvent;
    }

    public async Task<List<EventQueryModel>> SearchAsync(string value)
    {
        var events = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Where(x => x.IsConfirmed)
            .Where(x => x.Name.Contains(value))
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                IsConfirmed = x.IsConfirmed,
                DepartmentName = x.Department.Name,
                DepartmentSlug = x.Department.Slug,
                DepartmentLogo = x.Department.Logo,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
            }).OrderByDescending(x => x.Id).ToListAsync();

        return events;
    }

    public async Task<List<EventQueryModel>> GetEventsByPresenterAsync(string presenterSlug)
    {
        var presenterId = _eventContext.Presenters.FirstOrDefault(x => x.Slug == presenterSlug)!.Id;

        var events = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x => x.EventPresenters)
            .Where(x => x.IsConfirmed)
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                Address = x.Address,
                Description = x.Description,
                EventType = x.EventType,
                SupportNumber = x.SupportNumber,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                IsConfirmed = x.IsConfirmed,
                DepartmentName = x.Department.Name,
                DepartmentSlug = x.Department.Slug,
                DepartmentLogo = x.Department.Logo,
                PresenterIdList = x.EventPresenters.Select(p => p.PresenterId).ToList(),
            }).Where(x => x.PresenterIdList.Contains(presenterId)).OrderByDescending(x => x.Id).ToListAsync();

        return events;
    }

    private static List<TicketQueryModel> MapTickets(List<Ticket> tickets)
    {
        return tickets.Select(x => new TicketQueryModel
        {
            Id = x.Id,
            EventId = x.EventId,
            Title = x.Title,
            Price = x.Price,
            DiscountRate = x.DiscountRate,
            TotalPrice = x.TotalPrice,
            Description = x.Description,
            Number = x.Number,
            StartTime = x.StartTime,
            EndTime = x.EndTime
        }).ToList();
    }

    public bool UserOwned(long eventId, long accountId, long ticketId)
    {
        return _eventContext.Orders.Include(x => x.Ticket).Any(x =>
            x.AccountId == accountId && x.TicketId == ticketId && x.Ticket.EventId == eventId);
    }
}