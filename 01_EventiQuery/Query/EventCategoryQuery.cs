using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.EventCategory;
using Eventi.Domain.EventAgg;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class EventCategoryQuery : IEventCategoryQuery
{
    private readonly EventiContext _eventContext;

    public EventCategoryQuery(EventiContext eventContext)
    {
        _eventContext = eventContext;
    }

    public async Task<EventSubcategoryQueryModel> GetEventSubcategoryAsync(string slug)
    {
        return await _eventContext.EventSubcategories
            .Include(x => x.Events)
            .Select(x => new EventSubcategoryQueryModel
            {
                SubcategoryId = x.SubcategoryId,
                SubcategoryName = x.SubcategoryName,
                Slug = x.Slug,
                Events = MapEvents(x.Events)
            }).FirstOrDefaultAsync(x => x.Slug == slug) ?? new EventSubcategoryQueryModel();
    }

    public async Task<List<EventSubcategoryQueryModel>> GetEventSubcategoriesAsync()
    {
        return await _eventContext.EventSubcategories
            .Include(x => x.Events)
            .Select(x => new EventSubcategoryQueryModel
            {
                SubcategoryId = x.SubcategoryId,
                SubcategoryName = x.SubcategoryName,
                Slug = x.Slug,
                Events = MapEvents(x.Events)
            }).OrderByDescending(x => x.SubcategoryId).ToListAsync();
    }

    private static List<EventQueryModel> MapEvents(List<Event> events)
    {
        return events.Where(x => x.IsConfirmed).Select(x => new EventQueryModel
        {
            Id = x.Id,
            Slug = x.Slug,
            SubcategoryId = x.SubcategoryId,
            Name = x.Name,
            ImageCover = x.ImageCover,
            ImageCoverTitle = x.ImageCoverTitle,
            ImageCoverAlt = x.ImageCoverAlt
        }).ToList();
    }
}