using _01_EventiQuery.Contracts.Event;
using _01_EventiQuery.Contracts.EventCategory;
using Eventi.Domain.EventAgg;
using Eventi.Domain.EventCategoryAgg;
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

    public async Task<EventCategoryQueryModel> GetEventCategoryAsync(string slug)
    {
        return await _eventContext.EventCategories
            .Include(x => x.EventSubcategories)
            .Select(x => new EventCategoryQueryModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Slug = x.Slug,
                EventSubcategories = MapSubcategories(x.EventSubcategories)
            }).FirstOrDefaultAsync(x => x.Slug == slug) ?? new EventCategoryQueryModel();
    }

    public async Task<List<EventCategoryQueryModel>> GetEventCategoriesAsync()
    {
        return await _eventContext.EventCategories
            .Include(x => x.EventSubcategories)
            .Select(x => new EventCategoryQueryModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Slug = x.Slug,
                EventSubcategories = MapSubcategories(x.EventSubcategories)
            }).OrderByDescending(x => x.CategoryId).ToListAsync();
    }

    public async Task<EventSubcategoryQueryModel> GetEventSubcategoryAsync(string slug)
    {
        return await _eventContext.EventSubcategories
            .Include(x => x.Events)
            .Select(x => new EventSubcategoryQueryModel
            {
                SubcategoryId = x.SubcategoryId,
                CategoryId = x.CategoryId,
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
                CategoryId = x.CategoryId,
                SubcategoryName = x.SubcategoryName,
                Slug = x.Slug,
                Events = MapEvents(x.Events)
            }).OrderByDescending(x => x.SubcategoryId).ToListAsync();
    }

    private static List<EventSubcategoryQueryModel> MapSubcategories(List<EventSubcategory> subcategories)
    {
        return subcategories.Select(x => new EventSubcategoryQueryModel
        {
            SubcategoryName = x.SubcategoryName,
            Slug = x.Slug,
            CategoryId = x.CategoryId
        }).ToList();
    }

    private static List<EventQueryModel> MapEvents(List<Event> events)
    {
        return events.Select(x => new EventQueryModel
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