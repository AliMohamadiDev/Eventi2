using _01_EventiQuery.Contracts.Event;
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

    public async Task<EventQueryModel> GetEventDetailsAsync(string slug)
    {
        var event1 = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x=>x.EventInfo)
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                IsWebinar = x.IsWebinar,
                IsPrivate = x.IsPrivate,
                PayByCustomer = x.PayByCustomer,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                EventInfo = x.EventInfo,
                //Presenter = x.Presenter,
                //PresenterId = x.PresenterId
            }).FirstOrDefaultAsync(x => x.Slug == slug);

        return event1;
    }

    

    public async Task<List<EventQueryModel>> GetLatestEventsAsync(int number)
    {
        var events = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x => x.EventInfo)
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                IsWebinar = x.IsWebinar,
                IsPrivate = x.IsPrivate,
                PayByCustomer = x.PayByCustomer,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                EventInfo = x.EventInfo,
                //Presenter = x.Presenter,
                //PresenterId = x.PresenterId
            }).OrderByDescending(x => x.Id)
            .Take(number)
            .ToListAsync();

        return events;
    }

    public async Task<List<EventQueryModel>> SearchAsync(string value)
    {
        var events = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x => x.EventInfo)
            .Where(x=>x.Name.Contains(value))
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                IsWebinar = x.IsWebinar,
                IsPrivate = x.IsPrivate,
                PayByCustomer = x.PayByCustomer,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                EventInfo = x.EventInfo,
                //Presenter = x.Presenter,
                //PresenterId = x.PresenterId
            }).OrderByDescending(x => x.Id).ToListAsync();

        return events;
    }

    public async Task<List<EventQueryModel>> GetEventsByPresenterAsync(string presenterSlug)
    {
        var events = await _eventContext.Events
            .Include(x => x.Subcategory)
            .Include(x => x.EventInfo)
            .ThenInclude(x=>x.Event.EventPresenters)
            //.Where(x=>x.Presenter.Slug == presenterSlug)
            .Select(x => new EventQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ImageCover = x.ImageCover,
                ImageCoverAlt = x.ImageCoverAlt,
                ImageCoverTitle = x.ImageCoverTitle,
                IsWebinar = x.IsWebinar,
                IsPrivate = x.IsPrivate,
                PayByCustomer = x.PayByCustomer,
                SubcategoryId = x.SubcategoryId,
                SubcategorySlug = x.Subcategory.Slug,
                Subcategory = x.Subcategory.SubcategoryName,
                Tickets = MapTickets(x.Tickets),
                EventInfo = x.EventInfo,
                //Presenter = x.Presenter,
                //PresenterId = x.PresenterId
            }).OrderByDescending(x => x.Id).ToListAsync();
        
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
        /*var event1 = _eventContext.Events.Include(x => x.Tickets).ThenInclude(x => x.AccountTickets)
            .FirstOrDefault(x => x.Id == eventId);

        var account = event1.Tickets.FirstOrDefault(x=>x.AccountTickets.a)

        if (event1.Tickets.Any(x => x.Id == ticketId && x.AccountTickets.Any(x => x.AccountId == accountId)))
        {
            return true;
        }

        return false;*/


        var a = _eventContext.Orders.Include(x => x.Ticket).Any(x =>
            x.AccountId == accountId && x.TicketId == ticketId && x.Ticket.EventId == eventId);
        return a;
    }
}